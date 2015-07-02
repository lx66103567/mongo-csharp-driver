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

using System.Linq.Expressions;

namespace MongoDB.Driver.Linq.Expressions
{
    internal abstract class ExtensionExpression : Expression
    {
        public abstract ExtensionExpressionType ExtensionType { get; }

        public sealed override ExpressionType NodeType
        {
            get { return ExpressionType.Extension; }
        }

        protected sealed override Expression Accept(ExpressionVisitor visitor)
        {
            var mongoVisitor = visitor as ExtensionExpressionVisitor;
            if (mongoVisitor != null)
            {
                return Accept(mongoVisitor);
            }
            return base.Accept(visitor);
        }

        protected internal virtual Expression Accept(ExtensionExpressionVisitor visitor)
        {
            return visitor.VisitExtensionExpression(this);
        }
    }
}
