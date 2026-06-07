using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class UI_CollectedPiecesIndicator : MonoBehaviour
	{
		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_completedText;

		[SerializeField]
		private TextMeshProUGUI m_pieceCountText;

		[Space(10f)]
		[SerializeField]
		[CanBeNull]
		private TextMeshProUGUI m_assemblyCountText;

		private int m_total;

		private int m_value;

		public int Total
		{
			get
			{
				return m_total;
			}
			set
			{
				m_total = value;
				RefreshContent();
				CheckForAssemblePossibility();
			}
		}

		public int Value
		{
			get
			{
				return m_value;
			}
			set
			{
				m_value = value;
				RefreshContent();
				CheckForAssemblePossibility();
			}
		}

		protected void OnEnable()
		{
			RefreshContent();
		}

		private void RefreshContent()
		{
			m_pieceCountText.text = Value + "/" + Total;
		}

		private void CheckForAssemblePossibility()
		{
			if (m_assemblyCountText != null)
			{
				m_assemblyCountText.text = (CanAssemble() ? (Total / Value).ToString() : "0");
			}
		}

		public bool CanAssemble()
		{
			return Total == Value;
		}

		public void Assemble()
		{
			CheckForAssemblePossibility();
		}

		public void SetCompletedValue(int completedCount)
		{
			m_completedText.text = completedCount.ToString();
		}
	}
}
