using System;
using System.Collections.Generic;
using PajamaLlama.Procedural;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public class VoronoiTask : ThreadPoolManager.ITask
	{
		private List<Vector2> _sites;

		private Rect _bounds;

		private Exception _exception;

		public bool Completed { get; private set; }

		public VoronoiTask(List<Vector2> sites, Rect bounds)
		{
			_sites = sites;
			_bounds = bounds;
		}

		public void ThreadPoolWaitCallback(object state)
		{
			try
			{
				Execute();
			}
			catch (Exception exception)
			{
				_exception = exception;
			}
			finally
			{
				Completed = true;
			}
		}

		public void UnityCompletedCallback()
		{
			if (_exception != null)
			{
				throw _exception;
			}
		}

		private void Execute()
		{
			Voronoi.Generate(_sites, _bounds);
		}
	}
}
