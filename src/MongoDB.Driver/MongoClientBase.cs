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

using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Clusters;

namespace MongoDB.Driver
{
    /// <summary>
    /// Base class for implementors of <see cref="IMongoClient"/>.
    /// </summary>
    public abstract class MongoClientBase : IMongoClient
    {
        /// <inheritdoc />
        public abstract MongoClientSettings Settings { get; }

        /// <inheritdoc />
        public abstract Task DropDatabaseAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <inheritdoc />
        public abstract IMongoDatabase GetDatabase(string name, MongoDatabaseSettings settings = null);

        /// <inheritdoc />
        public abstract Task<IAsyncCursor<Bson.BsonDocument>> ListDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
