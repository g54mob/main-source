using System.ComponentModel;
using DV.Common;
using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class SaveLoadViewElement : AViewElement<ISaveGame>
	{
		[SerializeField]
		private TextMeshProUGUI saveName;

		[SerializeField]
		private TextMeshProUGUI saveDate;

		[SerializeField]
		private TextMeshProUGUI saveTime;

		[SerializeField]
		private GameObject autoSaveIcon;

		private ISaveGame data;

		public override void SetData(ISaveGame data, AGridView<ISaveGame> _)
		{
			if (this.data != null)
			{
				this.data = null;
			}
			if (data != null)
			{
				this.data = data;
			}
			UpdateView();
		}

		private void UpdateView(object sender = null, PropertyChangedEventArgs e = null)
		{
			saveName.text = data.Name;
			saveDate.text = LocalizationAPI.L($"month_{data.Timestamp.Month}", data.Timestamp.Day.ToString());
			saveTime.text = data.Timestamp.ToString("HH:mm");
			autoSaveIcon.SetActive(data.Type == SaveType.Auto);
		}
	}
}
