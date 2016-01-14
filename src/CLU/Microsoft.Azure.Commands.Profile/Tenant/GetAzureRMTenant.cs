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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile
{    
    /// <summary>
    /// Cmdlet to get user tenant information. 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmTenant")]
    [Alias("Get-AzureRmDomain")]
    [OutputType(typeof(PSAzureTenant))]
    [CliCommandAlias("tenant;ls")]
    public class GetAzureRMTenantCommand : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true)]
        [Alias("Domain", "Tenant", "t")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }
        
        protected override void ProcessRecord()
        {
            var profileClient = new RMProfileClient(AuthenticationFactory, ClientFactory, DefaultProfile);
            
            WriteObject(profileClient.ListTenants(TenantId).Select((t) => (PSAzureTenant)t), enumerateCollection: true);
        }
    }
}