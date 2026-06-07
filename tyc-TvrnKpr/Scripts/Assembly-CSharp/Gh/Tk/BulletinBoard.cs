using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class BulletinBoard : Prop
	{
		private Transform[] _normalModelPaperParents;

		private Transform[] _brokenModelPaperParents;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		private List<BulletinBoardPaper> _bulletinBoardPapers;

		public int AmountOfPapers => 0;

		public bool IsPosterAtPosition(int position)
		{
			return false;
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void AddPaper(int position, BulletinBoardPaper paper = null)
		{
		}

		protected virtual GameObject GetPaperPrefabForPosition(int position)
		{
			return null;
		}

		public virtual int GetRandomPostPosition()
		{
			return 0;
		}

		protected override void ActivateBrokenModel(bool activate)
		{
		}

		private static void SetParent(Transform parent, Transform child)
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		protected override void ChargeForUse(Patron patron, string usageKey)
		{
		}

		public void RemovePaper(int position, GameObjectX gox)
		{
		}

		public void NewPaper(int position, Transform targetTransform)
		{
		}

		public void DestroyPaper(BulletinBoardPaper bulletinPaper)
		{
		}
	}
}
