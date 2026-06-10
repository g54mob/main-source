using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class NewspaperController : MonoBehaviour
{
	[Serializable]
	public class InteractionDialogFeature
	{
		public string msgID;

		public int humanID;
	}

	[Serializable]
	public class NewspaperState
	{
		public float time;

		public string seed;

		public int murderID;

		public string mainArticle;

		public int mainContext;

		public string article2;

		public int art2Context;

		public string article3;

		public int art3Context;

		public string ad1;

		public int ad1Context;

		public string ad2;

		public int ad2Context;

		public string ad3;

		public int ad3Context;

		public string ad4;

		public int ad4Context;

		public void SerializeFields()
		{
		}
	}

	[Header("Components")]
	public TextMeshProUGUI newspaperTitleText;

	public TextMeshProUGUI newspaperDateText;

	[Space(7f)]
	public TextMeshProUGUI mainArticleHeadline;

	public TextMeshProUGUI mainArticleColumn1;

	public TextMeshProUGUI mainArticleColumn2;

	public TextMeshProUGUI mainArticleColumn3;

	[Space(7f)]
	public TextMeshProUGUI article2Headline;

	public TextMeshProUGUI article2Column1;

	public TextMeshProUGUI article2Column2;

	public TextMeshProUGUI article2Column3;

	[Space(7f)]
	public TextMeshProUGUI article3Headline;

	public TextMeshProUGUI article3Column1;

	public TextMeshProUGUI article3Column2;

	[Space(7f)]
	public TextMeshProUGUI ad1Text;

	public TextMeshProUGUI ad2Text;

	public TextMeshProUGUI ad3Text;

	public TextMeshProUGUI ad4Text;

	[Header("State")]
	public NewspaperState currentState;

	public List<InteractionDialogFeature> ddsFeaturedArticles;

	private static NewspaperController _instance;

	public static NewspaperController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateNewspaperReferences(NewspaperDisplayController disp)
	{
	}

	public void UpdateText(bool updateNewsTicker = false)
	{
	}

	public void SetTextForArticle(string msgID, int context, TextMeshProUGUI headline, TextMeshProUGUI[] columns, string lineBreaks = "\n\n")
	{
	}

	private object GetContextObject(int contextEnum, string seed)
	{
		return null;
	}

	public void SetAdText(string msgID, int context, TextMeshProUGUI adText)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateNewNewspaper()
	{
	}

	private bool PickArticleFromTrees(ref List<DDSSaveClasses.DDSTreeSave> trees, out string pickedArticleMsgID, out int pickedContext, List<string> ignoreMsgIDs = null, bool includeDDSArticles = false)
	{
		pickedArticleMsgID = null;
		pickedContext = default(int);
		return false;
	}
}
