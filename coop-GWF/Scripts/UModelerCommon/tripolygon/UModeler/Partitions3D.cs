namespace tripolygon.UModeler
{
	public class Partitions3D
	{
		public EditableMesh positives = new EditableMesh();

		public EditableMesh negatives = new EditableMesh();

		public EditableMesh coPositive = new EditableMesh();

		public EditableMesh coNegative = new EditableMesh();

		public void Join(Partitions3D partitions)
		{
			positives.Join(partitions.positives);
			negatives.Join(partitions.negatives);
			coPositive.Join(partitions.coPositive);
			coNegative.Join(partitions.coNegative);
		}
	}
}
