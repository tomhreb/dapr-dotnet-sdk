﻿// ------------------------------------------------------------------------
// Copyright 2024 The Dapr Authors
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//     http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ------------------------------------------------------------------------

using Dapr.Common;
using Autogenerated = Dapr.Client.Autogen.Grpc.v1;

namespace Dapr.Jobs;

/// <summary>
/// Builds a <see cref="DaprJobsClient"/>.
/// </summary>
public sealed class DaprJobsClientBuilder : DaprGenericClientBuilder<DaprJobsClient>
{
    /// <summary>
    /// Builds the client instance from the properties of the builder.
    /// </summary>
    /// <returns>The Dapr client instance.</returns>
    public override DaprJobsClient Build()
    {
        var daprClientDependencies = this.BuildDaprClientDependencies();

        var client = new Autogenerated.Dapr.DaprClient(daprClientDependencies.channel);
        var apiTokenHeader = this.DaprApiToken is not null ? DaprJobsClient.GetDaprApiTokenHeader(this.DaprApiToken) : null;

        return new DaprJobsGrpcClient(client, daprClientDependencies.httpClient, apiTokenHeader);
    }
}