using System.Collections.Generic;

namespace DV.Logic.Job
{
	public class TrainCompositionController
	{
		private static TrainCompositionController _instance;

		private List<TrainComposition> trainCompositions;

		public static TrainCompositionController Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TrainCompositionController();
				}
				return _instance;
			}
		}

		private TrainCompositionController()
		{
			trainCompositions = new List<TrainComposition>();
		}

		public bool Contains(TrainComposition trainComposition)
		{
			return trainCompositions.Contains(trainComposition);
		}

		public bool Contains(List<TrainComposition> trainCompositions)
		{
			foreach (TrainComposition trainComposition in trainCompositions)
			{
				if (!Contains(trainComposition))
				{
					return false;
				}
			}
			return true;
		}

		public void AddTrainComposition(TrainComposition trainComposition)
		{
			trainCompositions.Add(trainComposition);
		}

		public void RemoveTrainComposition(TrainComposition trainComposition)
		{
			trainCompositions.Remove(trainComposition);
		}
	}
}
