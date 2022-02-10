// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary> A Class representing a NamespaceDisasterRecoveryAuthorizationRule along with the instance operations that can be performed on it. </summary>
    public partial class NamespaceDisasterRecoveryAuthorizationRule : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="NamespaceDisasterRecoveryAuthorizationRule"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias, string authorizationRuleName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics;
        private readonly DisasterRecoveryAuthorizationRulesRestOperations _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesRestClient;
        private readonly ServiceBusAuthorizationRuleData _data;

        /// <summary> Initializes a new instance of the <see cref="NamespaceDisasterRecoveryAuthorizationRule"/> class for mocking. </summary>
        protected NamespaceDisasterRecoveryAuthorizationRule()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "NamespaceDisasterRecoveryAuthorizationRule"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal NamespaceDisasterRecoveryAuthorizationRule(ArmClient client, ServiceBusAuthorizationRuleData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="NamespaceDisasterRecoveryAuthorizationRule"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal NamespaceDisasterRecoveryAuthorizationRule(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceBus", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesApiVersion);
            _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesRestClient = new DisasterRecoveryAuthorizationRulesRestOperations(_namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.ServiceBus/namespaces/disasterRecoveryConfigs/authorizationRules";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ServiceBusAuthorizationRuleData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets an authorization rule for a namespace by rule name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}
        /// Operation Id: DisasterRecoveryAuthorizationRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<NamespaceDisasterRecoveryAuthorizationRule>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics.CreateScope("NamespaceDisasterRecoveryAuthorizationRule.Get");
            scope.Start();
            try
            {
                var response = await _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NamespaceDisasterRecoveryAuthorizationRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an authorization rule for a namespace by rule name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}
        /// Operation Id: DisasterRecoveryAuthorizationRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NamespaceDisasterRecoveryAuthorizationRule> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics.CreateScope("NamespaceDisasterRecoveryAuthorizationRule.Get");
            scope.Start();
            try
            {
                var response = _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NamespaceDisasterRecoveryAuthorizationRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the primary and secondary connection strings for the namespace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}/listKeys
        /// Operation Id: DisasterRecoveryAuthorizationRules_ListKeys
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<AccessKeys>> GetKeysAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics.CreateScope("NamespaceDisasterRecoveryAuthorizationRule.GetKeys");
            scope.Start();
            try
            {
                var response = await _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesRestClient.ListKeysAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the primary and secondary connection strings for the namespace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/disasterRecoveryConfigs/{alias}/authorizationRules/{authorizationRuleName}/listKeys
        /// Operation Id: DisasterRecoveryAuthorizationRules_ListKeys
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AccessKeys> GetKeys(CancellationToken cancellationToken = default)
        {
            using var scope = _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesClientDiagnostics.CreateScope("NamespaceDisasterRecoveryAuthorizationRule.GetKeys");
            scope.Start();
            try
            {
                var response = _namespaceDisasterRecoveryAuthorizationRuleDisasterRecoveryAuthorizationRulesRestClient.ListKeys(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
