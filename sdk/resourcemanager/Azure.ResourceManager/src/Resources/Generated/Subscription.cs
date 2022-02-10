// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A Class representing a Subscription along with the instance operations that can be performed on it. </summary>
    public partial class Subscription : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Subscription"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _subscriptionClientDiagnostics;
        private readonly SubscriptionsRestOperations _subscriptionRestClient;
        private readonly ClientDiagnostics _subscriptionResourcesClientDiagnostics;
        private readonly ResourcesRestOperations _subscriptionResourcesRestClient;
        private readonly ClientDiagnostics _subscriptionTagsClientDiagnostics;
        private readonly TagsRestOperations _subscriptionTagsRestClient;
        private readonly ClientDiagnostics _resourceLinkClientDiagnostics;
        private readonly ResourceLinksRestOperations _resourceLinkRestClient;
        private readonly ClientDiagnostics _featureClientDiagnostics;
        private readonly FeaturesRestOperations _featureRestClient;
        private readonly SubscriptionData _data;

        /// <summary> Initializes a new instance of the <see cref="Subscription"/> class for mocking. </summary>
        protected Subscription()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Subscription"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Subscription(ArmClient client, SubscriptionData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Subscription"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Subscription(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subscriptionClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string subscriptionApiVersion);
            _subscriptionRestClient = new SubscriptionsRestOperations(_subscriptionClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subscriptionApiVersion);
            _subscriptionResourcesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string subscriptionResourcesApiVersion);
            _subscriptionResourcesRestClient = new ResourcesRestOperations(_subscriptionResourcesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subscriptionResourcesApiVersion);
            _subscriptionTagsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string subscriptionTagsApiVersion);
            _subscriptionTagsRestClient = new TagsRestOperations(_subscriptionTagsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subscriptionTagsApiVersion);
            _resourceLinkClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ResourceLink.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceLink.ResourceType, out string resourceLinkApiVersion);
            _resourceLinkRestClient = new ResourceLinksRestOperations(_resourceLinkClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, resourceLinkApiVersion);
            _featureClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", Feature.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(Feature.ResourceType, out string featureApiVersion);
            _featureRestClient = new FeaturesRestOperations(_featureClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, featureApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Resources/subscriptions";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SubscriptionData Data
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

        /// <summary> Gets a collection of Providers in the Provider. </summary>
        /// <returns> An object representing collection of Providers and their operations over a Provider. </returns>
        public virtual ProviderCollection GetProviders()
        {
            return new ProviderCollection(Client, Id);
        }

        /// <summary> Gets a collection of ResourceGroups in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResourceGroups and their operations over a ResourceGroup. </returns>
        public virtual ResourceGroupCollection GetResourceGroups()
        {
            return new ResourceGroupCollection(Client, Id);
        }

        /// <summary> Gets a collection of SubscriptionPolicyDefinitions in the SubscriptionPolicyDefinition. </summary>
        /// <returns> An object representing collection of SubscriptionPolicyDefinitions and their operations over a SubscriptionPolicyDefinition. </returns>
        public virtual SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions()
        {
            return new SubscriptionPolicyDefinitionCollection(Client, Id);
        }

        /// <summary> Gets a collection of SubscriptionPolicySetDefinitions in the SubscriptionPolicySetDefinition. </summary>
        /// <returns> An object representing collection of SubscriptionPolicySetDefinitions and their operations over a SubscriptionPolicySetDefinition. </returns>
        public virtual SubscriptionPolicySetDefinitionCollection GetSubscriptionPolicySetDefinitions()
        {
            return new SubscriptionPolicySetDefinitionCollection(Client, Id);
        }

        /// <summary>
        /// Gets details about a specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}
        /// Operation Id: Subscriptions_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Subscription>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _subscriptionClientDiagnostics.CreateScope("Subscription.Get");
            scope.Start();
            try
            {
                var response = await _subscriptionRestClient.GetAsync(Id.SubscriptionId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _subscriptionClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Subscription(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets details about a specified subscription.
        /// Request Path: /subscriptions/{subscriptionId}
        /// Operation Id: Subscriptions_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Subscription> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _subscriptionClientDiagnostics.CreateScope("Subscription.Get");
            scope.Start();
            try
            {
                var response = _subscriptionRestClient.Get(Id.SubscriptionId, cancellationToken);
                if (response.Value == null)
                    throw _subscriptionClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Subscription(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows deleting a value from the list of predefined values for an existing predefined tag name. The value being deleted must not be in use as a tag value for the given tag name for any resource.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}/tagValues/{tagValue}
        /// Operation Id: Tags_DeleteValue
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is null. </exception>
        public async virtual Task<Response> DeletePredefinedTagValueAsync(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));
            Argument.AssertNotNullOrEmpty(tagValue, nameof(tagValue));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.DeletePredefinedTagValue");
            scope.Start();
            try
            {
                var response = await _subscriptionTagsRestClient.DeleteValueAsync(Id.SubscriptionId, tagName, tagValue, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows deleting a value from the list of predefined values for an existing predefined tag name. The value being deleted must not be in use as a tag value for the given tag name for any resource.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}/tagValues/{tagValue}
        /// Operation Id: Tags_DeleteValue
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is null. </exception>
        public virtual Response DeletePredefinedTagValue(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));
            Argument.AssertNotNullOrEmpty(tagValue, nameof(tagValue));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.DeletePredefinedTagValue");
            scope.Start();
            try
            {
                var response = _subscriptionTagsRestClient.DeleteValue(Id.SubscriptionId, tagName, tagValue, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows adding a value to the list of predefined values for an existing predefined tag name. A tag value can have a maximum of 256 characters.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}/tagValues/{tagValue}
        /// Operation Id: Tags_CreateOrUpdateValue
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is null. </exception>
        public async virtual Task<Response<PredefinedTagValue>> CreateOrUpdatePredefinedTagValueAsync(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));
            Argument.AssertNotNullOrEmpty(tagValue, nameof(tagValue));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.CreateOrUpdatePredefinedTagValue");
            scope.Start();
            try
            {
                var response = await _subscriptionTagsRestClient.CreateOrUpdateValueAsync(Id.SubscriptionId, tagName, tagValue, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows adding a value to the list of predefined values for an existing predefined tag name. A tag value can have a maximum of 256 characters.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}/tagValues/{tagValue}
        /// Operation Id: Tags_CreateOrUpdateValue
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="tagValue"> The value of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> or <paramref name="tagValue"/> is null. </exception>
        public virtual Response<PredefinedTagValue> CreateOrUpdatePredefinedTagValue(string tagName, string tagValue, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));
            Argument.AssertNotNullOrEmpty(tagValue, nameof(tagValue));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.CreateOrUpdatePredefinedTagValue");
            scope.Start();
            try
            {
                var response = _subscriptionTagsRestClient.CreateOrUpdateValue(Id.SubscriptionId, tagName, tagValue, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}
        /// Operation Id: Tags_CreateOrUpdate
        /// </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> is null. </exception>
        public async virtual Task<Response<PredefinedTag>> CreateOrUpdatePredefinedTagAsync(string tagName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.CreateOrUpdatePredefinedTag");
            scope.Start();
            try
            {
                var response = await _subscriptionTagsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, tagName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows adding a name to the list of predefined tag names for the given subscription. A tag name can have a maximum of 512 characters and is case-insensitive. Tag names cannot have the following prefixes which are reserved for Azure use: &apos;microsoft&apos;, &apos;azure&apos;, &apos;windows&apos;.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}
        /// Operation Id: Tags_CreateOrUpdate
        /// </summary>
        /// <param name="tagName"> The name of the tag to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> is null. </exception>
        public virtual Response<PredefinedTag> CreateOrUpdatePredefinedTag(string tagName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.CreateOrUpdatePredefinedTag");
            scope.Start();
            try
            {
                var response = _subscriptionTagsRestClient.CreateOrUpdate(Id.SubscriptionId, tagName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows deleting a name from the list of predefined tag names for the given subscription. The name being deleted must not be in use as a tag name for any resource. All predefined values for the given name must have already been deleted.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}
        /// Operation Id: Tags_Delete
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> is null. </exception>
        public async virtual Task<Response> DeletePredefinedTagAsync(string tagName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.DeletePredefinedTag");
            scope.Start();
            try
            {
                var response = await _subscriptionTagsRestClient.DeleteAsync(Id.SubscriptionId, tagName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation allows deleting a name from the list of predefined tag names for the given subscription. The name being deleted must not be in use as a tag name for any resource. All predefined values for the given name must have already been deleted.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames/{tagName}
        /// Operation Id: Tags_Delete
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="tagName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="tagName"/> is null. </exception>
        public virtual Response DeletePredefinedTag(string tagName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tagName, nameof(tagName));

            using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.DeletePredefinedTag");
            scope.Start();
            try
            {
                var response = _subscriptionTagsRestClient.Delete(Id.SubscriptionId, tagName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation performs a union of predefined tags, resource tags, resource group tags and subscription tags, and returns a summary of usage for each tag name and value under the given subscription. In case of a large number of tags, this operation may return a previously cached result.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames
        /// Operation Id: Tags_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PredefinedTag" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PredefinedTag> GetAllPredefinedTagsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PredefinedTag>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.GetAllPredefinedTags");
                scope.Start();
                try
                {
                    var response = await _subscriptionTagsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PredefinedTag>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.GetAllPredefinedTags");
                scope.Start();
                try
                {
                    var response = await _subscriptionTagsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// This operation performs a union of predefined tags, resource tags, resource group tags and subscription tags, and returns a summary of usage for each tag name and value under the given subscription. In case of a large number of tags, this operation may return a previously cached result.
        /// Request Path: /subscriptions/{subscriptionId}/tagNames
        /// Operation Id: Tags_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PredefinedTag" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PredefinedTag> GetAllPredefinedTags(CancellationToken cancellationToken = default)
        {
            Page<PredefinedTag> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.GetAllPredefinedTags");
                scope.Start();
                try
                {
                    var response = _subscriptionTagsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PredefinedTag> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subscriptionTagsClientDiagnostics.CreateScope("Subscription.GetAllPredefinedTags");
                scope.Start();
                try
                {
                    var response = _subscriptionTagsRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
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

        /// <summary>
        /// Gets all the linked resources for the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/links
        /// Operation Id: ResourceLinks_ListAtSubscription
        /// </summary>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceLink> GetResourceLinksAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceLink>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceLinkClientDiagnostics.CreateScope("Subscription.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = await _resourceLinkRestClient.ListAtSubscriptionAsync(Id.SubscriptionId, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResourceLink>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceLinkClientDiagnostics.CreateScope("Subscription.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = await _resourceLinkRestClient.ListAtSubscriptionNextPageAsync(nextLink, Id.SubscriptionId, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the linked resources for the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/links
        /// Operation Id: ResourceLinks_ListAtSubscription
        /// </summary>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceLink> GetResourceLinks(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ResourceLink> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _resourceLinkClientDiagnostics.CreateScope("Subscription.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = _resourceLinkRestClient.ListAtSubscription(Id.SubscriptionId, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResourceLink> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _resourceLinkClientDiagnostics.CreateScope("Subscription.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = _resourceLinkRestClient.ListAtSubscriptionNextPage(nextLink, Id.SubscriptionId, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list.
        /// Request Path: /subscriptions/{subscriptionId}/locations
        /// Operation Id: Subscriptions_ListLocations
        /// </summary>
        /// <param name="includeExtendedLocations"> Whether to include extended locations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="LocationExpanded" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LocationExpanded> GetLocationsAsync(bool? includeExtendedLocations = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<LocationExpanded>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionClientDiagnostics.CreateScope("Subscription.GetLocations");
                scope.Start();
                try
                {
                    var response = await _subscriptionRestClient.ListLocationsAsync(Id.SubscriptionId, includeExtendedLocations, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list.
        /// Request Path: /subscriptions/{subscriptionId}/locations
        /// Operation Id: Subscriptions_ListLocations
        /// </summary>
        /// <param name="includeExtendedLocations"> Whether to include extended locations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LocationExpanded" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LocationExpanded> GetLocations(bool? includeExtendedLocations = null, CancellationToken cancellationToken = default)
        {
            Page<LocationExpanded> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionClientDiagnostics.CreateScope("Subscription.GetLocations");
                scope.Start();
                try
                {
                    var response = _subscriptionRestClient.ListLocations(Id.SubscriptionId, includeExtendedLocations, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets all the preview features that are available through AFEC for the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Features/features
        /// Operation Id: Features_ListAll
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Feature" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Feature> GetFeaturesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Feature>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _featureClientDiagnostics.CreateScope("Subscription.GetFeatures");
                scope.Start();
                try
                {
                    var response = await _featureRestClient.ListAllAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Feature(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Feature>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _featureClientDiagnostics.CreateScope("Subscription.GetFeatures");
                scope.Start();
                try
                {
                    var response = await _featureRestClient.ListAllNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Feature(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the preview features that are available through AFEC for the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Features/features
        /// Operation Id: Features_ListAll
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Feature" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Feature> GetFeatures(CancellationToken cancellationToken = default)
        {
            Page<Feature> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _featureClientDiagnostics.CreateScope("Subscription.GetFeatures");
                scope.Start();
                try
                {
                    var response = _featureRestClient.ListAll(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Feature(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Feature> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _featureClientDiagnostics.CreateScope("Subscription.GetFeatures");
                scope.Start();
                try
                {
                    var response = _featureRestClient.ListAllNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Feature(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
