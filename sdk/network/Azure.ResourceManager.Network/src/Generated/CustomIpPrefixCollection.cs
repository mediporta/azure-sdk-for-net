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
    /// <summary> A class representing collection of CustomIpPrefix and their operations over its parent. </summary>
    public partial class CustomIpPrefixCollection : ArmCollection, IEnumerable<CustomIpPrefix>, IAsyncEnumerable<CustomIpPrefix>
    {
        private readonly ClientDiagnostics _customIpPrefixCustomIPPrefixesClientDiagnostics;
        private readonly CustomIPPrefixesRestOperations _customIpPrefixCustomIPPrefixesRestClient;

        /// <summary> Initializes a new instance of the <see cref="CustomIpPrefixCollection"/> class for mocking. </summary>
        protected CustomIpPrefixCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CustomIpPrefixCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CustomIpPrefixCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _customIpPrefixCustomIPPrefixesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", CustomIpPrefix.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(CustomIpPrefix.ResourceType, out string customIpPrefixCustomIPPrefixesApiVersion);
            _customIpPrefixCustomIPPrefixesRestClient = new CustomIPPrefixesRestOperations(_customIpPrefixCustomIPPrefixesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, customIpPrefixCustomIPPrefixesApiVersion);
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
        /// Creates or updates a custom IP prefix.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="parameters"> Parameters supplied to the create or update custom IP prefix operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<CustomIpPrefix>> CreateOrUpdateAsync(bool waitForCompletion, string customIpPrefixName, CustomIpPrefixData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _customIpPrefixCustomIPPrefixesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<CustomIpPrefix>(new CustomIpPrefixOperationSource(Client), _customIpPrefixCustomIPPrefixesClientDiagnostics, Pipeline, _customIpPrefixCustomIPPrefixesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a custom IP prefix.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="parameters"> Parameters supplied to the create or update custom IP prefix operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<CustomIpPrefix> CreateOrUpdate(bool waitForCompletion, string customIpPrefixName, CustomIpPrefixData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _customIpPrefixCustomIPPrefixesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<CustomIpPrefix>(new CustomIpPrefixOperationSource(Client), _customIpPrefixCustomIPPrefixesClientDiagnostics, Pipeline, _customIpPrefixCustomIPPrefixesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the specified custom IP prefix in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_Get
        /// </summary>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> is null. </exception>
        public async virtual Task<Response<CustomIpPrefix>> GetAsync(string customIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.Get");
            scope.Start();
            try
            {
                var response = await _customIpPrefixCustomIPPrefixesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new CustomIpPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified custom IP prefix in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_Get
        /// </summary>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> is null. </exception>
        public virtual Response<CustomIpPrefix> Get(string customIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.Get");
            scope.Start();
            try
            {
                var response = _customIpPrefixCustomIPPrefixesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, expand, cancellationToken);
                if (response.Value == null)
                    throw _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CustomIpPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all custom IP prefixes in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes
        /// Operation Id: CustomIPPrefixes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CustomIpPrefix" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CustomIpPrefix> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CustomIpPrefix>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _customIpPrefixCustomIPPrefixesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CustomIpPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CustomIpPrefix>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _customIpPrefixCustomIPPrefixesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CustomIpPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all custom IP prefixes in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes
        /// Operation Id: CustomIPPrefixes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CustomIpPrefix" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CustomIpPrefix> GetAll(CancellationToken cancellationToken = default)
        {
            Page<CustomIpPrefix> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _customIpPrefixCustomIPPrefixesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CustomIpPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CustomIpPrefix> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _customIpPrefixCustomIPPrefixesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CustomIpPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_Get
        /// </summary>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string customIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(customIpPrefixName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_Get
        /// </summary>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> is null. </exception>
        public virtual Response<bool> Exists(string customIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(customIpPrefixName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_Get
        /// </summary>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> is null. </exception>
        public async virtual Task<Response<CustomIpPrefix>> GetIfExistsAsync(string customIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _customIpPrefixCustomIPPrefixesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<CustomIpPrefix>(null, response.GetRawResponse());
                return Response.FromValue(new CustomIpPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/customIpPrefixes/{customIpPrefixName}
        /// Operation Id: CustomIPPrefixes_Get
        /// </summary>
        /// <param name="customIpPrefixName"> The name of the custom IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="customIpPrefixName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="customIpPrefixName"/> is null. </exception>
        public virtual Response<CustomIpPrefix> GetIfExists(string customIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(customIpPrefixName, nameof(customIpPrefixName));

            using var scope = _customIpPrefixCustomIPPrefixesClientDiagnostics.CreateScope("CustomIpPrefixCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _customIpPrefixCustomIPPrefixesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, customIpPrefixName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<CustomIpPrefix>(null, response.GetRawResponse());
                return Response.FromValue(new CustomIpPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CustomIpPrefix> IEnumerable<CustomIpPrefix>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CustomIpPrefix> IAsyncEnumerable<CustomIpPrefix>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
