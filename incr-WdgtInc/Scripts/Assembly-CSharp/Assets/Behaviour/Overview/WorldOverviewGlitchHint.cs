using System.Collections.Generic;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Overview
{
	public class WorldOverviewGlitchHint : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _sprite;

		private List<FramePrefabSet> _prefabs;

		private float _lifespanTimer;

		private Vector2 _destination;

		private bool _spawned;

		private int _i;

		private void Start()
		{
			_prefabs = new List<FramePrefabSet>(WorldManager.Instance.OrderedFramePrefabs);
			_destination = new Vector2((float)WorldMap.Current.GlitchLocation.x * 1.5f, (float)WorldMap.Current.GlitchLocation.y * 1.5f);
			_sprite.sprite = SeededRandom.Global.Choose(_prefabs).GetPreview().Icon;
		}

		private void Update()
		{
			_lifespanTimer += Time.deltaTime * 2f;
			if (_lifespanTimer > 0.66f)
			{
				_sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(0f, 1f, (1f - _lifespanTimer) * 3f));
			}
			if (_lifespanTimer > 0.1f && !_spawned)
			{
				_spawned = true;
				if (_i < 10)
				{
					Object.Instantiate(this, Vector2.MoveTowards(base.transform.position, _destination, 1f), Quaternion.identity, base.transform.parent)._i = _i + 1;
				}
			}
			else if (_lifespanTimer > 1f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
