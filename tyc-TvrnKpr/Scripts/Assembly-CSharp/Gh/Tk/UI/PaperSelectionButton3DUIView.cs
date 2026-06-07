using I18n;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class PaperSelectionButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _nameText;

		[SerializeField]
		private TextMeshProI18n _costText;

		[SerializeField]
		private SpriteRenderer _iconRenderer;

		[SerializeField]
		private Transform _isSelectedCheck;

		private string _nameKey;

		private int _cost;

		private string _paperId;

		public string NameKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Cost
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string PaperId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void ShowSelectedCheck(bool show)
		{
		}
	}
}
