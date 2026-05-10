using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.ContextMenu
{
	public abstract class ContextMenuActionButton<TAction> : MonoBehaviour where TAction : nz
	{
		[SerializeField]
		private Button m_button;

		[SerializeField]
		private TextMeshProUGUI m_name;

		protected TAction puy
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		protected string puz
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		private void Start()
		{
		}

		public void dwo(TAction a)
		{
		}

		public void dwp()
		{
		}

		protected virtual void dwq()
		{
		}

		protected virtual void dwr()
		{
		}

		protected virtual void dws()
		{
		}

		private void dwt()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
