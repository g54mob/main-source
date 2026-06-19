using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct CreatorCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;

		public ObjectDataCD objectData;

		public int numberLeft;

		public float timer;

		public float timeBetweenCreates;
	}
}
