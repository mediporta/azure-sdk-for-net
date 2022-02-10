// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of PrivateEndpoint and their operations over its parent. </summary>
    public partial class PrivateEndpointCollection : ArmCollection, IEnumerable<PrivateEndpoint>, IAsyncEnumerable<PrivateEndpoint>
    {
        private readonly ClientDiagnostics _privateEndpointClientDiagnostics;
        private readonly PrivateEndpointsRestOperations _privateEndpointRestClient;

        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointCollection"/> class for mocking. </summary>
        protected PrivateEndpointCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PrivateEndpointCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _privateEndpointClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", PrivateEndpoint.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(PrivateEndpoint.ResourceType, out string privateEndpointApiVersion);
            _privateEndpointRestClient = new PrivateEndpointsRestOperations(_privateEndpointClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, privateEndpointApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates an private endpoint in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="parameters"> Parameters supplied to the create or update private endpoint operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<PrivateEndpoint>> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointName, PrivateEndpointData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _privateEndpointRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<PrivateEndpoint>(new PrivateEndpointOperationSource(Client), _privateEndpointClientDiagnostics, Pipeline, _privateEndpointRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates an private endpoint in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="parameters"> Parameters supplied to the create or update private endpoint operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<PrivateEndpoint> CreateOrUpdate(bool waitForCompletion, string privateEndpointName, PrivateEndpointData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _privateEndpointRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<PrivateEndpoint>(new PrivateEndpointOperationSource(Client), _privateEndpointClientDiagnostics, Pipeline, _privateEndpointRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified private endpoint by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_Get
        /// </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> is null. </exception>
        public async virtual Task<Response<PrivateEndpoint>> GetAsync(string privateEndpointName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.Get");
            scope.Start();
            try
            {
                var response = await _privateEndpointRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _privateEndpointClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PrivateEndpoint(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified private endpoint by resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_Get
        /// </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> is null. </exception>
        public virtual Response<PrivateEndpoint> Get(string privateEndpointName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.Get");
            scope.Start();
            try
            {
                var response = _privateEndpointRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, expand, cancellationToken);
                if (response.Value == null)
                    throw _privateEndpointClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateEndpoint(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all private endpoints in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints
        /// Operation Id: PrivateEndpoints_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PrivateEndpoint" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateEndpoint> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PrivateEndpoint>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _privateEndpointRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpoint(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PrivateEndpoint>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _privateEndpointRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpoint(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all private endpoints in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints
        /// Operation Id: PrivateEndpoints_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateEndpoint" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateEndpoint> GetAll(CancellationToken cancellationToken = default)
        {
            Page<PrivateEndpoint> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _privateEndpointRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpoint(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PrivateEndpoint> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _privateEndpointRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateEndpoint(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_Get
        /// </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string privateEndpointName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(privateEndpointName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_Get
        /// </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> is null. </exception>
        public virtual Response<bool> Exists(string privateEndpointName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(privateEndpointName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_Get
        /// </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> is null. </exception>
        public async virtual Task<Response<PrivateEndpoint>> GetIfExistsAsync(string privateEndpointName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _privateEndpointRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PrivateEndpoint>(null, response.GetRawResponse());
                return Response.FromValue(new PrivateEndpoint(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}
        /// Operation Id: PrivateEndpoints_Get
        /// </summary>
        /// <param name="privateEndpointName"> The name of the private endpoint. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointName"/> is null. </exception>
        public virtual Response<PrivateEndpoint> GetIfExists(string privateEndpointName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointName, nameof(privateEndpointName));

            using var scope = _privateEndpointClientDiagnostics.CreateScope("PrivateEndpointCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _privateEndpointRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, privateEndpointName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PrivateEndpoint>(null, response.GetRawResponse());
                return Response.FromValue(new PrivateEndpoint(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PrivateEndpoint> IEnumerable<PrivateEndpoint>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PrivateEndpoint> IAsyncEnumerable<PrivateEndpoint>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
