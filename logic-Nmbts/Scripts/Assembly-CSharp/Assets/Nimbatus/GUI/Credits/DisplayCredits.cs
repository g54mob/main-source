using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Credits
{
	public class DisplayCredits : MonoBehaviour
	{
		public GameObject[] TeamCredits;

		public GameObject[] TranslatorCredits;

		public GameObject[] BackerCredits;

		public void Start()
		{
			TranslatorCredits.ForEach(delegate(GameObject o)
			{
				o.SetActive(false);
			});
			BackerCredits.ForEach(delegate(GameObject o)
			{
				o.SetActive(false);
			});
			TeamCredits.ForEach(delegate(GameObject o)
			{
				o.SetActive(true);
			});
		}

		public void Toggle(ECreditsType type)
		{
			switch (type)
			{
			case ECreditsType.Team:
				TranslatorCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				BackerCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				TeamCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(true);
				});
				break;
			case ECreditsType.Translator:
				TeamCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				BackerCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				TranslatorCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(true);
				});
				break;
			case ECreditsType.Backer:
				TeamCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				TranslatorCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(false);
				});
				BackerCredits.ForEach(delegate(GameObject o)
				{
					o.SetActive(true);
				});
				break;
			}
		}
	}
}
