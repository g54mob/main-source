using System;
using System.Collections.Generic;
using System.Globalization;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.CredentialManagement
{
	public class SAMLEndpointManager
	{
		private NamedSettingsManager settingsManager;

		public static bool IsAvailable => NamedSettingsManager.IsAvailable;

		public SAMLEndpointManager()
		{
			settingsManager = new NamedSettingsManager("SAMLEndpoints");
		}

		public void RegisterEndpoint(SAMLEndpoint samlEndpoint)
		{
			Dictionary<string, string> properties = new Dictionary<string, string>
			{
				{
					"Endpoint",
					samlEndpoint.EndpointUri.ToString()
				},
				{
					"AuthenticationType",
					samlEndpoint.AuthenticationType.ToString()
				}
			};
			settingsManager.RegisterObject(samlEndpoint.Name, properties);
		}

		public bool TryGetEndpoint(string endpointName, out SAMLEndpoint samlEndpoint)
		{
			samlEndpoint = null;
			try
			{
				samlEndpoint = GetEndpoint(endpointName);
			}
			catch (AmazonClientException exception)
			{
				Logger.GetLogger(typeof(SAMLEndpointManager)).Error(exception, "Unable to load SAML Endpoint '{0}'.", endpointName);
			}
			return samlEndpoint != null;
		}

		public SAMLEndpoint GetEndpoint(string endpointName)
		{
			if (settingsManager.TryGetObject(endpointName, out var properties))
			{
				try
				{
					if (properties.TryGetValue("AuthenticationType", out var value))
					{
						return new SAMLEndpoint(endpointName, properties["Endpoint"], value);
					}
					return new SAMLEndpoint(endpointName, properties["Endpoint"], null);
				}
				catch (Exception innerException)
				{
					throw new AmazonClientException(string.Format(CultureInfo.InvariantCulture, "Error reading A SAML endpoint with name {0}.", endpointName), innerException);
				}
			}
			throw new AmazonClientException(string.Format(CultureInfo.InvariantCulture, "There is no SAML endpoint registered with name {0}.", endpointName));
		}

		public void UnregisterEndpoint(string endpointName)
		{
			settingsManager.UnregisterObject(endpointName);
		}

		public List<string> ListEndpointNames()
		{
			return settingsManager.ListObjectNames();
		}

		public List<SAMLEndpoint> ListEndpoints()
		{
			List<SAMLEndpoint> list = new List<SAMLEndpoint>();
			foreach (string item in settingsManager.ListObjectNames())
			{
				if (TryGetEndpoint(item, out var samlEndpoint))
				{
					list.Add(samlEndpoint);
				}
			}
			return list;
		}
	}
}
