using Dhs5.Utility.Databases;
using UnityEngine;

namespace Dhs5.Utility.Tags
{
	public class GameplayTag : BaseDataContainerScriptableElement, IDataContainerPrefixableElement
	{
		[SerializeField]
		private string m_category;

		public string DataNamePrefix
		{
			get
			{
				return m_category;
			}
			set
			{
				m_category = value;
			}
		}
	}
}
