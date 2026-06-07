using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERPostInstances
	{
		public GameObject instance;

		public GameObject source;

		public ERTrafficPosts erTrafficPost;

		public ERConnectionSibling sibling;

		public ERPostInstances(GameObject _instance, GameObject _source, ERTrafficPosts _erTrafficPost, ERConnectionSibling _sibling)
		{
			instance = _instance;
			source = _source;
			erTrafficPost = _erTrafficPost;
			sibling = _sibling;
		}
	}
}
