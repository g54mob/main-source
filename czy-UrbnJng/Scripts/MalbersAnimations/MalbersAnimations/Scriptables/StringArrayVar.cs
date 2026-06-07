using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/String Array", order = 1000)]
	public class StringArrayVar : StringVar
	{
		[SerializeField]
		private IntReference index = new IntReference(-1);

		[SerializeField]
		private List<string> array = new List<string>();

		public override string Value
		{
			get
			{
				if (array != null && array.Count > 0)
				{
					if ((int)index == -1)
					{
						return array[Random.Range(0, array.Count)];
					}
					return array[(int)index % array.Count];
				}
				return string.Empty;
			}
			set
			{
				if (array != null && array.Count > 0 && (int)index != -1)
				{
					array[Index] = value;
				}
			}
		}

		public int Index
		{
			get
			{
				return index.Value;
			}
			set
			{
				index.Value = value;
			}
		}
	}
}
