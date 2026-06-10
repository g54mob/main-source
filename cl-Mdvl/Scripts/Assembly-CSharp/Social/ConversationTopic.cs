using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace Social
{
	[Serializable]
	public class ConversationTopic : Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int weight;

		[SerializeField]
		private List<string> lifeEventLogIds;

		[SerializeField]
		private List<string> affectionEffectors;

		[SerializeField]
		private List<float> affectionThresholds;

		[SerializeField]
		private List<string> beliefEffectors;

		[SerializeField]
		private List<float> beliefThresholds;

		public int Weight => weight;

		public List<string> AffectionEffectors => affectionEffectors;

		public List<float> AffectionThresholds => affectionThresholds;

		public List<string> BeliefEffectors => beliefEffectors;

		public List<float> BeliefThresholds => beliefThresholds;

		public override string GetID()
		{
			return id;
		}

		public string GetLifeEventLogId(string affectionEffector)
		{
			int num = affectionEffectors.IndexOf(affectionEffector);
			if (num != -1)
			{
				return lifeEventLogIds[num];
			}
			return null;
		}
	}
}
