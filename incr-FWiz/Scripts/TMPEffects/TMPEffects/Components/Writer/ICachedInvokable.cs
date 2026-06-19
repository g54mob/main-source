using TMPEffects.Tags;

namespace TMPEffects.Components.Writer
{
	internal interface ICachedInvokable : ITagWrapper
	{
		bool Triggered { get; }

		bool ExecuteInstantly { get; }

		bool ExecuteOnSkip { get; }

		bool ExecuteRepeatable { get; }

		void Reset();

		void Trigger();
	}
}
