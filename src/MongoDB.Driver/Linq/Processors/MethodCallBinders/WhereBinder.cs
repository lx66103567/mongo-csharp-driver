/* Copyright 2010-2015 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver.Linq.Expressions;

namespace MongoDB.Driver.Linq.Processors.MethodCallBinders
{
    internal class WhereBinder : IMethodCallBinder
    {
        public Expression Bind(ProjectionExpression projection, ProjectionBindingContext context, MethodCallExpression node, IEnumerable<Expression> arguments)
        {
            var lambda = ExtensionExpressionVisitor.GetLambda(arguments.Single());
            var binder = new AccumulatorBinder(context.GroupMap, context.SerializerRegistry);
            binder.RegisterParameterReplacement(lambda.Parameters[0], projection.Projector);

            var predicate = binder.Bind(lambda.Body);

            return new ProjectionExpression(
                new WhereExpression(
                    projection.Source,
                    predicate),
                projection.Projector,
                projection.Aggregator);
        }
    }
}
