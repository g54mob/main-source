using System;
using System.Collections.Generic;
using Restory.Gameplay.RandomBallsPoolSystems;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Data.RandomBallsPoolSystems
{
	public abstract class RandomBallsPoolSystemSettings<TBallSourceObject> : RandomBallsPoolSystemSettingsBase
	{
		[Serializable]
		private class BallSource : RandomBallSourceBase
		{
			[SerializeField]
			private TBallSourceObject targetObject;

			public TBallSourceObject TargetObject => targetObject;

			public BallSource(int id, TBallSourceObject targetObject = default(TBallSourceObject), int weight = 1)
			{
				base.id = id;
				this.targetObject = targetObject;
				base.weight = weight;
			}

			public void AssignNewID(int newID)
			{
				id = newID;
			}

			public void SetWeight(int newWeight)
			{
				weight = newWeight;
			}
		}

		[SerializeField]
		private List<BallSource> randomObjects = new List<BallSource>();

		[SerializeField]
		private int highestUsedID;

		protected virtual bool IsRandomObjectsListReadOnly => false;

		public void RefillBallsPool(List<RandomBallsPoolBall<TBallSourceObject>> ballsPool)
		{
			ballsPool.Clear();
			foreach (BallSource randomObject in randomObjects)
			{
				for (int i = 0; i < randomObject.Weight; i++)
				{
					ballsPool.Add(new RandomBallsPoolBall<TBallSourceObject>
					{
						BallSourceID = randomObject.ID,
						TargetObject = randomObject.TargetObject
					});
				}
			}
		}

		public List<int> GetInitialBallsIdsList()
		{
			List<int> list = new List<int>();
			foreach (BallSource randomObject in randomObjects)
			{
				if ((!(randomObject.TargetObject is UnityEngine.Object obj) || (bool)obj) && randomObject.TargetObject != null)
				{
					list.Add(randomObject.ID);
				}
			}
			return list;
		}

		public Dictionary<int, int> GetRemainingBallsIdsDictionary(List<RandomBallsPoolBall<TBallSourceObject>> ballsPool)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (BallSource randomObject in randomObjects)
			{
				if ((randomObject.TargetObject is UnityEngine.Object obj && !obj) || randomObject.TargetObject == null)
				{
					continue;
				}
				foreach (RandomBallsPoolBall<TBallSourceObject> item in ballsPool)
				{
					if (item.BallSourceID == randomObject.ID && !dictionary.TryAdd(randomObject.ID, 1))
					{
						dictionary[randomObject.ID]++;
					}
				}
			}
			return dictionary;
		}

		public void RestoreBallsPool(List<RandomBallsPoolBall<TBallSourceObject>> ballsPool, Dictionary<int, int> remainingBallsIdsDictionary, IEnumerable<int> savedInitialBallsIds)
		{
			ballsPool.Clear();
			List<int> value;
			using (CollectionPool<List<int>, int>.Get(out value))
			{
				value.AddRange(savedInitialBallsIds);
				foreach (BallSource randomObject in randomObjects)
				{
					if ((randomObject.TargetObject is UnityEngine.Object obj && !obj) || randomObject.TargetObject == null)
					{
						continue;
					}
					if (remainingBallsIdsDictionary.TryGetValue(randomObject.ID, out var value2))
					{
						int num = ((value2 > randomObject.Weight) ? randomObject.Weight : value2);
						for (int i = 0; i < num; i++)
						{
							ballsPool.Add(new RandomBallsPoolBall<TBallSourceObject>
							{
								BallSourceID = randomObject.ID,
								TargetObject = randomObject.TargetObject
							});
						}
					}
					else if (!value.Contains(randomObject.ID))
					{
						for (int j = 0; j < randomObject.Weight; j++)
						{
							ballsPool.Add(new RandomBallsPoolBall<TBallSourceObject>
							{
								BallSourceID = randomObject.ID,
								TargetObject = randomObject.TargetObject
							});
						}
					}
				}
			}
		}

		public bool TryGetObjectByBallSourceID(int id, out TBallSourceObject foundObject)
		{
			foreach (BallSource randomObject in randomObjects)
			{
				if (randomObject != null && randomObject.ID == id)
				{
					foundObject = randomObject.TargetObject;
					return true;
				}
			}
			foundObject = default(TBallSourceObject);
			return false;
		}

		private int GenerateNewBallSourceID()
		{
			int iD = highestUsedID;
			foreach (BallSource randomObject in randomObjects)
			{
				if (randomObject.ID > iD)
				{
					iD = randomObject.ID;
				}
			}
			return highestUsedID = iD + 1;
		}
	}
}
