using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class NormalSymbol : BaseMiracleSymbol
	{
		public SpriteRenderer normalGround;

		public HitEffect clickEffect;

		public override bool UpdateOk => false;

		public override void Init(MiracleInfo miracleInfo)
		{
		}

		public override double UpdateMiracle(double deltatime, RaycastHit hit)
		{
			return 0.0;
		}

		public override void SymbolMove(Vector3 mousePos)
		{
		}

		public override void SymbolEnter()
		{
		}

		public override void SymbolExit()
		{
		}

		public bool SearchMultiAttackCircle(Vector3 searchOrigin, float radius, out List<Collider2D> hits)
		{
			hits = null;
			return false;
		}

		private void InflictDamage(GameObject hit)
		{
		}
	}
}
