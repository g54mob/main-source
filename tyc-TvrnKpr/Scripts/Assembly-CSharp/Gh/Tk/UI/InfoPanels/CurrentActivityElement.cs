using System;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class CurrentActivityElement : MonoBehaviour
	{
		public TextMeshProI18n HighLevel;

		public TextMeshProI18n Detail;

		public Button3DUIView AbortButton;

		private Actor _actor;

		public Actor Actor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnTaskDescriptionChanged(object sender, EventArgs e)
		{
		}

		private void Refresh()
		{
		}
	}
}
