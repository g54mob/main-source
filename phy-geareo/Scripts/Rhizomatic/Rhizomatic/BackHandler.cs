using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic
{
	public class BackHandler : MonoBehaviour
	{
		public List<BackHandlerItem> items;

		private bool blockPop;

		public static BackHandler instance { get; private set; }

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		public bool Pop()
		{
			return false;
		}

		public BackHandlerItem PushItem(Func<bool> func)
		{
			return null;
		}

		public void RemoveItem(BackHandlerItem item)
		{
		}

		public static BackHandlerItem Push(Func<bool> func)
		{
			return null;
		}

		public static void Remove(BackHandlerItem item)
		{
		}

		public static BackHandlerItem Push(Action action)
		{
			return null;
		}

		public static BackHandlerItem PushBlock()
		{
			return null;
		}
	}
}
