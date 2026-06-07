using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Credits
{
	public class DisplayBackerCredits : MonoBehaviour
	{
		public TextAsset CreditsFile;

		public UITable Table;

		public UILabel LabelPrefab;

		public void Start()
		{
			string[] array = ParseText();
			int num = 0;
			UILabel uILabel = null;
			UILabel uILabel2 = null;
			int num2 = 80;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (text == "")
				{
					continue;
				}
				if (text.StartsWith(">$"))
				{
					Object.Instantiate(LabelPrefab, Table.transform).text = LabelHelper.NewLine + LabelHelper.Orange + text.Remove(0, 2);
					Object.Instantiate(LabelPrefab, Table.transform).text = LabelHelper.NewLine;
					uILabel2 = Object.Instantiate(LabelPrefab, Table.transform);
					uILabel = Object.Instantiate(LabelPrefab, Table.transform);
					num = 0;
					continue;
				}
				if (uILabel == null || uILabel2 == null || num >= num2)
				{
					uILabel2 = Object.Instantiate(LabelPrefab, Table.transform);
					uILabel = Object.Instantiate(LabelPrefab, Table.transform);
					num = 0;
				}
				if (i % 2 == 0)
				{
					UILabel uILabel3 = uILabel;
					uILabel3.text = uILabel3.text + text + ((num >= num2 - 2) ? "" : LabelHelper.NewLine);
				}
				else
				{
					UILabel uILabel4 = uILabel2;
					uILabel4.text = uILabel4.text + text + ((num >= num2 - 2) ? "" : LabelHelper.NewLine);
				}
				num++;
			}
			Table.enabled = true;
			Table.Reposition();
		}

		private string[] ParseText()
		{
			return CreditsFile.text.Split("\n"[0]);
		}
	}
}
