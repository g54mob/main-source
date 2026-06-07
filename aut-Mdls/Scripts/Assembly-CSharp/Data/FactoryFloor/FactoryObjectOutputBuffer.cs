using Data.FactoryFloor.Resources;
using Data.Operator;

namespace Data.FactoryFloor
{
	public class FactoryObjectOutputBuffer
	{
		public IResourceHolder ResourceHolder { get; private set; }

		public bool HasResourceHolder { get; private set; }

		public Resource ResourceTryingToOutput { get; private set; }

		public bool IsTryingToOutput => ResourceTryingToOutput != null;

		public void SetOutputResourceHolder(IResourceHolder resourceHolder)
		{
			ResourceHolder = resourceHolder;
			HasResourceHolder = true;
		}

		public void SetTryingToOutput(Resource resource)
		{
			ResourceTryingToOutput = resource;
		}

		public void StopTryingToOutput()
		{
			ResourceTryingToOutput = null;
		}

		public void Reset()
		{
			ResourceTryingToOutput = null;
			ResourceHolder = null;
			HasResourceHolder = false;
		}

		public void OutputResource(Resource resource, FactoryObjectData.InputData inputData)
		{
			ResourceTryingToOutput = null;
			ResourceHolder.AddResource(resource, inputData);
		}
	}
}
