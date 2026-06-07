using Assets.Source.Buff;
using UnityEngine;

namespace Assets.Behaviour.Overview
{
	public class WorldOverviewCellBuff : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _progress;

		private FrameBuff _buff;

		private WorldOverviewCell _parent;

		public FrameBuff Buff => _buff;

		private void Awake()
		{
			_parent = GetComponentInParent<WorldOverviewCell>();
		}

		private void Update()
		{
			float progress = _buff.Progress;
			if (progress <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				_progress.transform.localScale = new Vector3(Mathf.Clamp01(progress), 1f, 1f);
			}
		}

		public void SetBuff(FrameBuff ab)
		{
			_progress.color = ab.WorldColor;
			_buff = ab;
		}
	}
}
