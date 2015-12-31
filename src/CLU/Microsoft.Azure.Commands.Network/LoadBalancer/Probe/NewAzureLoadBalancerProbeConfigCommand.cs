﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmLoadBalancerProbeConfig"), OutputType(typeof(PSProbe))]
    public class NewAzureLoadBalancerProbeConfigCommand : AzureLoadBalancerProbeConfigBase
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var probe = new PSProbe();
            probe.Name = this.Name;
            probe.Port = this.Port;
            probe.Protocol = this.Protocol;
            probe.RequestPath = this.RequestPath;
            probe.IntervalInSeconds = this.IntervalInSeconds;
            probe.NumberOfProbes = this.ProbeCount;

            probe.Id =
                ChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerProbeName,
                    this.Name);

            WriteObject(probe);
        }
    }
}
