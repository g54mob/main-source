using System.Collections.Generic;

public class SamplesController : Controller, ILogOrigin
{
	public enum Type
	{
		Tutorials = 0,
		Examples = 1
	}

	private struct SampleGadget
	{
		public string path;

		public SerializedGadgetMetaData metadata;

		public SampleGadget(string path, SerializedGadgetMetaData metadata)
		{
			this.path = null;
			this.metadata = null;
		}
	}

	private Dictionary<uint, SampleGadget> gadgetMetadatasDictionary;

	private Dictionary<Type, List<uint>> sampleGadgetsOfType;

	public static string samplesPath => null;

	public static string gadgetsPath => null;

	public override void Init()
	{
	}

	private void ScanType(Type type)
	{
	}

	private uint GenerateGuid()
	{
		return 0u;
	}

	private void RegisterGadget(string path, SerializedGadgetMetaData metadata, Type type)
	{
	}

	public Dictionary<Type, SerializedGadgetMetaData[]> GetGadgetMetadatas()
	{
		return null;
	}

	public SerializedGadget GetSerializedGadget(uint guid)
	{
		return null;
	}
}
