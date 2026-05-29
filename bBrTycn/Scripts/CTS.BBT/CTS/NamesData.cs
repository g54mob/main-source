using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class NamesData
	{
		[SerializeField]
		private string firstname;

		[SerializeField]
		private string lastname;

		public string Firstname
		{
			get
			{
				return firstname;
			}
			set
			{
				firstname = value;
			}
		}

		public string Lastname
		{
			get
			{
				return lastname;
			}
			set
			{
				lastname = value;
			}
		}
	}
}
