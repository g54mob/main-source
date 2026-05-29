using UnityEngine;

namespace Battle
{
	public abstract class BaseMiracleSymbol : MonoBehaviour
	{
		[Label("参照用(マスタから取得)")]
		public MiracleInfo miracleInfo;

		public Transform symbolRoot;

		public Vector3 symbolOffset;

		public BaseMiracle baseMiracle;

		public abstract bool UpdateOk { get; }

		public abstract void Init(MiracleInfo miracleInfo);

		public abstract double UpdateMiracle(double deltatime, RaycastHit hit);

		public virtual void SymbolEnter()
		{
		}

		public virtual void SymbolMove(Vector3 mousePos)
		{
		}

		public virtual void SymbolExit()
		{
		}

		public Vector3 GetHitLocalPos(RaycastHit hit)
		{
			return default(Vector3);
		}

		public void PlayShootingSE(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void PlayHitSE(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void PlayMissSE(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}
	}
}
