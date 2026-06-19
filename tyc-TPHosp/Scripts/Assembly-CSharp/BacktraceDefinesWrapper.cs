using Backtrace.Unity;
using Backtrace.Unity.Model;
using JetBrains.Annotations;
using TH20;
using UnityEngine;

public class BacktraceDefinesWrapper : MonoBehaviour
{
	public BacktraceClient backtraceClient;

	public BacktraceConfiguration backtraceConfiguration;

	private void Start()
	{
		if (!(backtraceClient == null) && !(backtraceConfiguration == null))
		{
			backtraceClient.enabled = false;
			backtraceClient.Configuration = backtraceConfiguration;
			backtraceClient.enabled = true;
			backtraceClient.Refresh();
			DefineCustomTrackingAttributes();
		}
	}

	[UsedImplicitly]
	private void DefineCustomTrackingAttributes()
	{
		if (!(backtraceClient == null))
		{
			backtraceClient.BeforeSend = delegate(BacktraceData model)
			{
				model.Attributes.Attributes.Add("tph_version", GameVersionNumber.Version.VersionString);
				model.Attributes.Attributes.Remove("application.data_path");
				model.Attributes.Attributes.Remove("hostname");
				model.Attributes.Attributes.Remove("device.name");
				model.Attributes.Attributes.Remove("application.temporary_cache");
				model.Annotation.EnvironmentVariables.Clear();
				return model;
			};
		}
	}
}
