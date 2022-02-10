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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Storage
{
    /// <summary> A class representing collection of DeletedAccount and their operations over its parent. </summary>
    public partial class DeletedAccountCollection : ArmCollection
    {
        private readonly ClientDiagnostics _deletedAccountClientDiagnostics;
        private readonly DeletedAccountsRestOperations _deletedAccountRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeletedAccountCollection"/> class for mocking. </summary>
        protected DeletedAccountCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedAccountCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeletedAccountCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedAccountClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", DeletedAccount.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(DeletedAccount.ResourceType, out string deletedAccountApiVersion);
            _deletedAccountRestClient = new DeletedAccountsRestOperations(_deletedAccountClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedAccountApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get properties of specified deleted account resource.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// Operation Id: DeletedAccounts_Get
        /// </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public async virtual Task<Response<DeletedAccount>> GetAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Get");
            scope.Start();
            try
            {
                var response = await _deletedAccountRestClient.GetAsync(Id.SubscriptionId, location, deletedAccountName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _deletedAccountClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get properties of specified deleted account resource.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// Operation Id: DeletedAccounts_Get
        /// </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public virtual Response<DeletedAccount> Get(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Get");
            scope.Start();
            try
            {
                var response = _deletedAccountRestClient.Get(Id.SubscriptionId, location, deletedAccountName, cancellationToken);
                if (response.Value == null)
                    throw _deletedAccountClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// Operation Id: DeletedAccounts_Get
        /// </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(location, deletedAccountName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// Operation Id: DeletedAccounts_Get
        /// </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public virtual Response<bool> Exists(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(location, deletedAccountName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// Operation Id: DeletedAccounts_Get
        /// </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public async virtual Task<Response<DeletedAccount>> GetIfExistsAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _deletedAccountRestClient.GetAsync(Id.SubscriptionId, location, deletedAccountName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DeletedAccount>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// Operation Id: DeletedAccounts_Get
        /// </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public virtual Response<DeletedAccount> GetIfExists(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deletedAccountRestClient.Get(Id.SubscriptionId, location, deletedAccountName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DeletedAccount>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
