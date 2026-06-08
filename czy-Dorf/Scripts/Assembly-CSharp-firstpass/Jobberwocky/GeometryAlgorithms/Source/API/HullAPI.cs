using System;
using Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull2D;
using Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull3D;
using Jobberwocky.GeometryAlgorithms.Source.Core;
using Jobberwocky.GeometryAlgorithms.Source.Parameters;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.API
{
	public class HullAPI : ThreadingAPI
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<IParameters, Action<Geometry>, ThreadingResult> _003C_003E9__0_0;

			internal ThreadingResult _003CHull2DAsync_003Eb__0_0(IParameters param, Action<Geometry> callbackResult)
			{
				Geometry output = new Hull2DWrapper().Hull2D((Hull2DParameters)param);
				return new ThreadingResult(callbackResult, output);
			}
		}

		public void Hull2DAsync(Action<Geometry> callback, Hull2DParameters parameters)
		{
			ThreadingAPI.StartWorker(delegate(IParameters param, Action<Geometry> callbackResult)
			{
				Geometry output = new Hull2DWrapper().Hull2D((Hull2DParameters)param);
				return new ThreadingResult(callbackResult, output);
			}, parameters, callback);
		}

		public Mesh Hull2D(Hull2DParameters parameters)
		{
			return Hull2DRaw(parameters).ToUnityMesh();
		}

		public Geometry Hull2DRaw(Hull2DParameters parameters)
		{
			return new Hull2DWrapper().Hull2D(parameters);
		}

		public Mesh ConvexHull3D(Hull3DParameters parameters)
		{
			return ConvexHull3DRaw(parameters).ToUnityMesh();
		}

		public Geometry ConvexHull3DRaw(Hull3DParameters parameters)
		{
			return new Hull3DWrapper().Hull3D(parameters);
		}
	}
}
