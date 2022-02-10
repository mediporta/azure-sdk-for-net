// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppConfiguration
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((client) =>
            {
                return new SubscriptionExtensionClient(client, subscription.Id);
            }
            );
        }

        /// <summary>
        /// Lists the configuration stores for a given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/configurationStores
        /// Operation Id: ConfigurationStores_List
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="skipToken"> A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConfigurationStore" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ConfigurationStore> GetConfigurationStoresAsync(this Subscription subscription, string skipToken = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetConfigurationStoresAsync(skipToken, cancellationToken);
        }

        /// <summary>
        /// Lists the configuration stores for a given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/configurationStores
        /// Operation Id: ConfigurationStores_List
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="skipToken"> A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConfigurationStore" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ConfigurationStore> GetConfigurationStores(this Subscription subscription, string skipToken = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetConfigurationStores(skipToken, cancellationToken);
        }

        /// <summary>
        /// Checks whether the configuration store name is available for use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/checkNameAvailability
        /// Operation Id: CheckAppConfigurationNameAvailability
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="checkNameAvailabilityParameters"> The object containing information for the availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="checkNameAvailabilityParameters"/> is null. </exception>
        public async static Task<Response<NameAvailabilityStatus>> CheckAppConfigurationNameAvailabilityAsync(this Subscription subscription, CheckNameAvailabilityParameters checkNameAvailabilityParameters, CancellationToken cancellationToken = default)
        {
            if (checkNameAvailabilityParameters == null)
            {
                throw new ArgumentNullException(nameof(checkNameAvailabilityParameters));
            }

            return await GetExtensionClient(subscription).CheckAppConfigurationNameAvailabilityAsync(checkNameAvailabilityParameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks whether the configuration store name is available for use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/checkNameAvailability
        /// Operation Id: CheckAppConfigurationNameAvailability
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="checkNameAvailabilityParameters"> The object containing information for the availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="checkNameAvailabilityParameters"/> is null. </exception>
        public static Response<NameAvailabilityStatus> CheckAppConfigurationNameAvailability(this Subscription subscription, CheckNameAvailabilityParameters checkNameAvailabilityParameters, CancellationToken cancellationToken = default)
        {
            if (checkNameAvailabilityParameters == null)
            {
                throw new ArgumentNullException(nameof(checkNameAvailabilityParameters));
            }

            return GetExtensionClient(subscription).CheckAppConfigurationNameAvailability(checkNameAvailabilityParameters, cancellationToken);
        }
    }
}
