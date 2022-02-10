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

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a ManagementGroupPolicySetDefinition along with the instance operations that can be performed on it. </summary>
    public partial class ManagementGroupPolicySetDefinition : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ManagementGroupPolicySetDefinition"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string policySetDefinitionName)
        {
            var resourceId = $"/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics;
        private readonly PolicySetDefinitionsRestOperations _managementGroupPolicySetDefinitionPolicySetDefinitionsRestClient;
        private readonly PolicySetDefinitionData _data;

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupPolicySetDefinition"/> class for mocking. </summary>
        protected ManagementGroupPolicySetDefinition()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ManagementGroupPolicySetDefinition"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ManagementGroupPolicySetDefinition(ArmClient client, PolicySetDefinitionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupPolicySetDefinition"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagementGroupPolicySetDefinition(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string managementGroupPolicySetDefinitionPolicySetDefinitionsApiVersion);
            _managementGroupPolicySetDefinitionPolicySetDefinitionsRestClient = new PolicySetDefinitionsRestOperations(_managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managementGroupPolicySetDefinitionPolicySetDefinitionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/policySetDefinitions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PolicySetDefinitionData Data
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
        /// This operation retrieves the policy set definition in the given management group with the given name.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetAtManagementGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagementGroupPolicySetDefinition>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("ManagementGroupPolicySetDefinition.Get");
            scope.Start();
            try
            {
                var response = await _managementGroupPolicySetDefinitionPolicySetDefinitionsRestClient.GetAtManagementGroupAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagementGroupPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the policy set definition in the given management group with the given name.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_GetAtManagementGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagementGroupPolicySetDefinition> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("ManagementGroupPolicySetDefinition.Get");
            scope.Start();
            try
            {
                var response = _managementGroupPolicySetDefinitionPolicySetDefinitionsRestClient.GetAtManagementGroup(Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagementGroupPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation deletes the policy set definition in the given management group with the given name.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_DeleteAtManagementGroup
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("ManagementGroupPolicySetDefinition.Delete");
            scope.Start();
            try
            {
                var response = await _managementGroupPolicySetDefinitionPolicySetDefinitionsRestClient.DeleteAtManagementGroupAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation deletes the policy set definition in the given management group with the given name.
        /// Request Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_DeleteAtManagementGroup
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _managementGroupPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("ManagementGroupPolicySetDefinition.Delete");
            scope.Start();
            try
            {
                var response = _managementGroupPolicySetDefinitionPolicySetDefinitionsRestClient.DeleteAtManagementGroup(Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new ResourcesArmOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
