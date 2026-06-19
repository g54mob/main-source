using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

namespace PugWorldGen
{
	public interface ShapeEnumerator : IEnumerator<int2>, IEnumerator, IDisposable
	{
	}
}
