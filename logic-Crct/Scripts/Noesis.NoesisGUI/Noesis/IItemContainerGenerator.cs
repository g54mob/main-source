using System;

namespace Noesis
{
	public interface IItemContainerGenerator
	{
		ItemContainerGenerator GetItemContainerGeneratorForPanel(Panel panel);

		IDisposable StartAt(GeneratorPosition position, GeneratorDirection direction);

		IDisposable StartAt(GeneratorPosition position, GeneratorDirection direction, bool allowStartAtRealizedItem);

		DependencyObject GenerateNext();

		DependencyObject GenerateNext(out bool isNewlyRealized);

		void PrepareItemContainer(DependencyObject container);

		void RemoveAll();

		void Remove(GeneratorPosition position, int count);

		GeneratorPosition GeneratorPositionFromIndex(int itemIndex);

		int IndexFromGeneratorPosition(GeneratorPosition position);
	}
}
