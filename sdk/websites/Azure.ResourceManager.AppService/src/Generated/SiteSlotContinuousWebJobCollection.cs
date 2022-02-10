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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of ContinuousWebJob and their operations over its parent. </summary>
    public partial class SiteSlotContinuousWebJobCollection : ArmCollection, IEnumerable<SiteSlotContinuousWebJob>, IAsyncEnumerable<SiteSlotContinuousWebJob>
    {
        private readonly ClientDiagnostics _siteSlotContinuousWebJobWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotContinuousWebJobWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotContinuousWebJobCollection"/> class for mocking. </summary>
        protected SiteSlotContinuousWebJobCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotContinuousWebJobCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteSlotContinuousWebJobCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotContinuousWebJobWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotContinuousWebJob.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SiteSlotContinuousWebJob.ResourceType, out string siteSlotContinuousWebJobWebAppsApiVersion);
            _siteSlotContinuousWebJobWebAppsRestClient = new WebAppsRestOperations(_siteSlotContinuousWebJobWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotContinuousWebJobWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteSlot.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteSlot.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Gets a continuous web job by its ID for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}
        /// Operation Id: WebApps_GetContinuousWebJobSlot
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public async virtual Task<Response<SiteSlotContinuousWebJob>> GetAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotContinuousWebJobWebAppsRestClient.GetContinuousWebJobSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, webJobName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotContinuousWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets a continuous web job by its ID for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}
        /// Operation Id: WebApps_GetContinuousWebJobSlot
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<SiteSlotContinuousWebJob> Get(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotContinuousWebJobWebAppsRestClient.GetContinuousWebJobSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, webJobName, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotContinuousWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for List continuous web jobs for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs
        /// Operation Id: WebApps_ListContinuousWebJobsSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteSlotContinuousWebJob" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteSlotContinuousWebJob> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteSlotContinuousWebJob>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotContinuousWebJobWebAppsRestClient.ListContinuousWebJobsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotContinuousWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteSlotContinuousWebJob>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotContinuousWebJobWebAppsRestClient.ListContinuousWebJobsSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotContinuousWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for List continuous web jobs for an app, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs
        /// Operation Id: WebApps_ListContinuousWebJobsSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteSlotContinuousWebJob" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteSlotContinuousWebJob> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteSlotContinuousWebJob> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotContinuousWebJobWebAppsRestClient.ListContinuousWebJobsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotContinuousWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteSlotContinuousWebJob> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotContinuousWebJobWebAppsRestClient.ListContinuousWebJobsSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotContinuousWebJob(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}
        /// Operation Id: WebApps_GetContinuousWebJobSlot
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(webJobName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}
        /// Operation Id: WebApps_GetContinuousWebJobSlot
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<bool> Exists(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(webJobName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}
        /// Operation Id: WebApps_GetContinuousWebJobSlot
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public async virtual Task<Response<SiteSlotContinuousWebJob>> GetIfExistsAsync(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotContinuousWebJobWebAppsRestClient.GetContinuousWebJobSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, webJobName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotContinuousWebJob>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotContinuousWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/continuouswebjobs/{webJobName}
        /// Operation Id: WebApps_GetContinuousWebJobSlot
        /// </summary>
        /// <param name="webJobName"> Name of Web Job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="webJobName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="webJobName"/> is null. </exception>
        public virtual Response<SiteSlotContinuousWebJob> GetIfExists(string webJobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(webJobName, nameof(webJobName));

            using var scope = _siteSlotContinuousWebJobWebAppsClientDiagnostics.CreateScope("SiteSlotContinuousWebJobCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotContinuousWebJobWebAppsRestClient.GetContinuousWebJobSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, webJobName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotContinuousWebJob>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotContinuousWebJob(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteSlotContinuousWebJob> IEnumerable<SiteSlotContinuousWebJob>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteSlotContinuousWebJob> IAsyncEnumerable<SiteSlotContinuousWebJob>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
