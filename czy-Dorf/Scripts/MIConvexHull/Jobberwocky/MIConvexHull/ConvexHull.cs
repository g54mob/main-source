using System;
using System.Collections.Generic;
using System.Linq;

namespace Jobberwocky.MIConvexHull
{
	public static class ConvexHull
	{
		public static ConvexHullCreationResult<TVertex, DefaultConvexFace<TVertex>> Create<TVertex>(IList<TVertex> data, double tolerance = 1E-10) where TVertex : IVertex
		{
			return ConvexHull<TVertex, DefaultConvexFace<TVertex>>.Create(data, tolerance);
		}
	}
	public class ConvexHull<TVertex, TFace> where TVertex : IVertex where TFace : ConvexFace<TVertex, TFace>, new()
	{
		private IEnumerable<TVertex> _003CPoints_003Ek__BackingField;

		private IEnumerable<TFace> _003CFaces_003Ek__BackingField;

		public IEnumerable<TVertex> Points
		{
			get
			{
				return _003CPoints_003Ek__BackingField;
			}
			internal set
			{
				_003CPoints_003Ek__BackingField = value;
			}
		}

		public IEnumerable<TFace> Faces
		{
			get
			{
				return _003CFaces_003Ek__BackingField;
			}
			internal set
			{
				_003CFaces_003Ek__BackingField = value;
			}
		}

		internal ConvexHull()
		{
		}

		internal static ConvexHullCreationResult<TVertex, TFace> Create(IList<TVertex> data, double tolerance)
		{
			if (data == null)
			{
				throw new ArgumentNullException("The supplied data is null.");
			}
			try
			{
				ConvexHullAlgorithm convexHullAlgorithm = new ConvexHullAlgorithm(Enumerable.ToArray(Enumerable.Cast<IVertex>(data)), lift: false, tolerance);
				convexHullAlgorithm.GetConvexHull();
				ConvexHull<TVertex, TFace> result = new ConvexHull<TVertex, TFace>
				{
					Points = convexHullAlgorithm.GetHullVertices(data),
					Faces = convexHullAlgorithm.GetConvexFaces<TVertex, TFace>()
				};
				return new ConvexHullCreationResult<TVertex, TFace>(result, ConvexHullCreationResultOutcome.Success);
			}
			catch (ConvexHullGenerationException ex)
			{
				return new ConvexHullCreationResult<TVertex, TFace>(null, ex.Error, ex.ErrorMessage);
			}
			catch (Exception ex2)
			{
				return new ConvexHullCreationResult<TVertex, TFace>(null, ConvexHullCreationResultOutcome.UnknownError, ex2.Message);
			}
		}
	}
}
