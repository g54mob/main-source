using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class EvidenceMultiPage : Evidence
{
	[Serializable]
	public class MultiPageContent
	{
		public int page;

		public string evID;

		public int meta;

		public string discEvID;

		public Discovery disc;

		public string seperation;

		public string str;

		public int order;

		public Evidence GetEvidence()
		{
			return null;
		}
	}

	public delegate void PageChanged(int newPage);

	public List<MultiPageContent> pageContent;

	public int page;

	public event PageChanged OnPageChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public EvidenceMultiPage(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public int AddStringContentToNewPage(string newStr, string appendSeperation = "\n\n", int order = -1)
	{
		return 0;
	}

	public void AddStringContentToPage(int page, string newStr, string appendSeperation = "\n\n", int order = -1)
	{
	}

	public int AddContainedMetaObjectToNewPage(MetaObject containedMetaObject)
	{
		return 0;
	}

	public void AddContainedMetaObjectToPage(int page, MetaObject containedMetaObject)
	{
	}

	public int AddEvidenceToNewPage(Evidence evidenceToAdd)
	{
		return 0;
	}

	public void AddEvidenceToPage(int page, Evidence evidenceToAdd)
	{
	}

	public int AddEvidenceDiscoveryToNewPage(Evidence evidenceToApplyTo, Discovery discovery)
	{
		return 0;
	}

	public void AddEvidenceDiscoveryToPage(int page, Evidence evidenceToApplyTo, Discovery discovery)
	{
	}

	public void SetPage(int newPage, bool loopPages)
	{
	}

	public List<MultiPageContent> GetContentForPage(int newPage)
	{
		return null;
	}

	public string GetCurrentPageStringContent()
	{
		return null;
	}
}
