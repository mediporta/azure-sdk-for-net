// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a virtual machine scale set network profile's IP
    /// configuration. NOTE: The subnet of a scale set may be modified as long
    /// as the original subnet and the new subnet are in the same virtual
    /// network
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetUpdateIPConfiguration class.
        /// </summary>
        public VirtualMachineScaleSetUpdateIPConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineScaleSetUpdateIPConfiguration class.
        /// </summary>
        /// <param name="id">Resource Id</param>
        /// <param name="name">The IP configuration name.</param>
        /// <param name="subnet">The subnet.</param>
        /// <param name="primary">Specifies the primary IP Configuration in
        /// case the network interface has more than one IP
        /// Configuration.</param>
        /// <param name="publicIPAddressConfiguration">The
        /// publicIPAddressConfiguration.</param>
        /// <param name="privateIPAddressVersion">Available from Api-Version
        /// 2017-03-30 onwards, it represents whether the specific
        /// ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        /// Possible values are: 'IPv4' and 'IPv6'. Possible values include:
        /// 'IPv4', 'IPv6'</param>
        /// <param name="applicationGatewayBackendAddressPools">The application
        /// gateway backend address pools.</param>
        /// <param name="applicationSecurityGroups">Specifies an array of
        /// references to application security group.</param>
        /// <param name="loadBalancerBackendAddressPools">The load balancer
        /// backend address pools.</param>
        /// <param name="loadBalancerInboundNatPools">The load balancer inbound
        /// nat pools.</param>
        public VirtualMachineScaleSetUpdateIPConfiguration(string id = default(string), string name = default(string), ApiEntityReference subnet = default(ApiEntityReference), bool? primary = default(bool?), VirtualMachineScaleSetUpdatePublicIPAddressConfiguration publicIPAddressConfiguration = default(VirtualMachineScaleSetUpdatePublicIPAddressConfiguration), string privateIPAddressVersion = default(string), IList<SubResource> applicationGatewayBackendAddressPools = default(IList<SubResource>), IList<SubResource> applicationSecurityGroups = default(IList<SubResource>), IList<SubResource> loadBalancerBackendAddressPools = default(IList<SubResource>), IList<SubResource> loadBalancerInboundNatPools = default(IList<SubResource>))
            : base(id)
        {
            Name = name;
            Subnet = subnet;
            Primary = primary;
            PublicIPAddressConfiguration = publicIPAddressConfiguration;
            PrivateIPAddressVersion = privateIPAddressVersion;
            ApplicationGatewayBackendAddressPools = applicationGatewayBackendAddressPools;
            ApplicationSecurityGroups = applicationSecurityGroups;
            LoadBalancerBackendAddressPools = loadBalancerBackendAddressPools;
            LoadBalancerInboundNatPools = loadBalancerInboundNatPools;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the IP configuration name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subnet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public ApiEntityReference Subnet { get; set; }

        /// <summary>
        /// Gets or sets specifies the primary IP Configuration in case the
        /// network interface has more than one IP Configuration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.primary")]
        public bool? Primary { get; set; }

        /// <summary>
        /// Gets or sets the publicIPAddressConfiguration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicIPAddressConfiguration")]
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration PublicIPAddressConfiguration { get; set; }

        /// <summary>
        /// Gets or sets available from Api-Version 2017-03-30 onwards, it
        /// represents whether the specific ipconfiguration is IPv4 or IPv6.
        /// Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
        /// Possible values include: 'IPv4', 'IPv6'
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddressVersion")]
        public string PrivateIPAddressVersion { get; set; }

        /// <summary>
        /// Gets or sets the application gateway backend address pools.
        /// </summary>
        [JsonProperty(PropertyName = "properties.applicationGatewayBackendAddressPools")]
        public IList<SubResource> ApplicationGatewayBackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets specifies an array of references to application
        /// security group.
        /// </summary>
        [JsonProperty(PropertyName = "properties.applicationSecurityGroups")]
        public IList<SubResource> ApplicationSecurityGroups { get; set; }

        /// <summary>
        /// Gets or sets the load balancer backend address pools.
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancerBackendAddressPools")]
        public IList<SubResource> LoadBalancerBackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets the load balancer inbound nat pools.
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancerInboundNatPools")]
        public IList<SubResource> LoadBalancerInboundNatPools { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (PublicIPAddressConfiguration != null)
            {
                PublicIPAddressConfiguration.Validate();
            }
        }
    }
}
