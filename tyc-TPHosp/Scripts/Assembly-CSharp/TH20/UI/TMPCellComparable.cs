using System;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[AddComponentMenu("UI/TextMeshPro Cell Comparable", 101)]
	public class TMPCellComparable : MonoBehaviour, IComparable<TMPCellComparable>, IComparable
	{
		[SerializeField]
		private TMP_Text _text;

		public TMP_Text Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
			}
		}

		public int CompareTo(TMPCellComparable other)
		{
			if (other != null && other._text != null)
			{
				return _text.text.CompareTo(other._text.text);
			}
			return 1;
		}

		public int CompareTo(object obj)
		{
			TMPCellComparable tMPCellComparable = obj as TMPCellComparable;
			if (!(tMPCellComparable != null))
			{
				return 1;
			}
			return CompareTo(tMPCellComparable);
		}
	}
}
