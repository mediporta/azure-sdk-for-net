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
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteSlotConfigWeb along with the instance operations that can be performed on it. </summary>
    public partial class SiteSlotConfigWeb : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteSlotConfigWeb"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteSlotConfigWebWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotConfigWebWebAppsRestClient;
        private readonly ClientDiagnostics _siteSlotConfigSnapshotWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotConfigSnapshotWebAppsRestClient;
        private readonly SiteConfigData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotConfigWeb"/> class for mocking. </summary>
        protected SiteSlotConfigWeb()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteSlotConfigWeb"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteSlotConfigWeb(ArmClient client, SiteConfigData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotConfigWeb"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteSlotConfigWeb(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotConfigWebWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string siteSlotConfigWebWebAppsApiVersion);
            _siteSlotConfigWebWebAppsRestClient = new WebAppsRestOperations(_siteSlotConfigWebWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotConfigWebWebAppsApiVersion);
            _siteSlotConfigSnapshotWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotConfigSnapshot.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SiteSlotConfigSnapshot.ResourceType, out string siteSlotConfigSnapshotWebAppsApiVersion);
            _siteSlotConfigSnapshotWebAppsRestClient = new WebAppsRestOperations(_siteSlotConfigSnapshotWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotConfigSnapshotWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/slots/config";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SiteConfigData Data
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

        /// <summary> Gets a collection of SiteSlotConfigSnapshots in the SiteSlotConfigSnapshot. </summary>
        /// <returns> An object representing collection of SiteSlotConfigSnapshots and their operations over a SiteSlotConfigSnapshot. </returns>
        public virtual SiteSlotConfigSnapshotCollection GetSiteSlotConfigSnapshots()
        {
            return new SiteSlotConfigSnapshotCollection(Client, Id);
        }

        /// <summary>
        /// Description for Gets the configuration of an app, such as platform version and bitness, default documents, virtual applications, Always On, etc.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web
        /// Operation Id: WebApps_GetConfigurationSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteSlotConfigWeb>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotConfigWebWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotConfigWebWebAppsRestClient.GetConfigurationSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotConfigWebWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotConfigWeb(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the configuration of an app, such as platform version and bitness, default documents, virtual applications, Always On, etc.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web
        /// Operation Id: WebApps_GetConfigurationSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteSlotConfigWeb> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotConfigWebWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.Get");
            scope.Start();
            try
            {
                var response = _siteSlotConfigWebWebAppsRestClient.GetConfigurationSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotConfigWebWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotConfigWeb(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates the configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web
        /// Operation Id: WebApps_UpdateConfigurationSlot
        /// </summary>
        /// <param name="siteConfig"> JSON representation of a SiteConfig object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteConfig"/> is null. </exception>
        public async virtual Task<Response<SiteSlotConfigWeb>> UpdateAsync(SiteConfigData siteConfig, CancellationToken cancellationToken = default)
        {
            if (siteConfig == null)
            {
                throw new ArgumentNullException(nameof(siteConfig));
            }

            using var scope = _siteSlotConfigWebWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.Update");
            scope.Start();
            try
            {
                var response = await _siteSlotConfigWebWebAppsRestClient.UpdateConfigurationSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteConfig, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotConfigWeb(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates the configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web
        /// Operation Id: WebApps_UpdateConfigurationSlot
        /// </summary>
        /// <param name="siteConfig"> JSON representation of a SiteConfig object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteConfig"/> is null. </exception>
        public virtual Response<SiteSlotConfigWeb> Update(SiteConfigData siteConfig, CancellationToken cancellationToken = default)
        {
            if (siteConfig == null)
            {
                throw new ArgumentNullException(nameof(siteConfig));
            }

            using var scope = _siteSlotConfigWebWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.Update");
            scope.Start();
            try
            {
                var response = _siteSlotConfigWebWebAppsRestClient.UpdateConfigurationSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteConfig, cancellationToken);
                return Response.FromValue(new SiteSlotConfigWeb(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates the configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web
        /// Operation Id: WebApps_CreateOrUpdateConfigurationSlot
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="siteConfig"> JSON representation of a SiteConfig object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteConfig"/> is null. </exception>
        public async virtual Task<ArmOperation<SiteSlotConfigWeb>> CreateOrUpdateAsync(bool waitForCompletion, SiteConfigData siteConfig, CancellationToken cancellationToken = default)
        {
            if (siteConfig == null)
            {
                throw new ArgumentNullException(nameof(siteConfig));
            }

            using var scope = _siteSlotConfigWebWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteSlotConfigWebWebAppsRestClient.CreateOrUpdateConfigurationSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteConfig, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<SiteSlotConfigWeb>(Response.FromValue(new SiteSlotConfigWeb(Client, response), response.GetRawResponse()));
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
        /// Description for Updates the configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web
        /// Operation Id: WebApps_CreateOrUpdateConfigurationSlot
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="siteConfig"> JSON representation of a SiteConfig object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteConfig"/> is null. </exception>
        public virtual ArmOperation<SiteSlotConfigWeb> CreateOrUpdate(bool waitForCompletion, SiteConfigData siteConfig, CancellationToken cancellationToken = default)
        {
            if (siteConfig == null)
            {
                throw new ArgumentNullException(nameof(siteConfig));
            }

            using var scope = _siteSlotConfigWebWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteSlotConfigWebWebAppsRestClient.CreateOrUpdateConfigurationSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteConfig, cancellationToken);
                var operation = new AppServiceArmOperation<SiteSlotConfigWeb>(Response.FromValue(new SiteSlotConfigWeb(Client, response), response.GetRawResponse()));
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
        /// Description for Gets a list of web app configuration snapshots identifiers. Each element of the list contains a timestamp and the ID of the snapshot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots
        /// Operation Id: WebApps_ListConfigurationSnapshotInfoSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteConfigurationSnapshotInfo" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteConfigurationSnapshotInfo> GetConfigurationSnapshotInfoSlotAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteConfigurationSnapshotInfo>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotConfigSnapshotWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.GetConfigurationSnapshotInfoSlot");
                scope.Start();
                try
                {
                    var response = await _siteSlotConfigSnapshotWebAppsRestClient.ListConfigurationSnapshotInfoSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteConfigurationSnapshotInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotConfigSnapshotWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.GetConfigurationSnapshotInfoSlot");
                scope.Start();
                try
                {
                    var response = await _siteSlotConfigSnapshotWebAppsRestClient.ListConfigurationSnapshotInfoSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Gets a list of web app configuration snapshots identifiers. Each element of the list contains a timestamp and the ID of the snapshot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/web/snapshots
        /// Operation Id: WebApps_ListConfigurationSnapshotInfoSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteConfigurationSnapshotInfo" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteConfigurationSnapshotInfo> GetConfigurationSnapshotInfoSlot(CancellationToken cancellationToken = default)
        {
            Page<SiteConfigurationSnapshotInfo> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotConfigSnapshotWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.GetConfigurationSnapshotInfoSlot");
                scope.Start();
                try
                {
                    var response = _siteSlotConfigSnapshotWebAppsRestClient.ListConfigurationSnapshotInfoSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteConfigurationSnapshotInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotConfigSnapshotWebAppsClientDiagnostics.CreateScope("SiteSlotConfigWeb.GetConfigurationSnapshotInfoSlot");
                scope.Start();
                try
                {
                    var response = _siteSlotConfigSnapshotWebAppsRestClient.ListConfigurationSnapshotInfoSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
