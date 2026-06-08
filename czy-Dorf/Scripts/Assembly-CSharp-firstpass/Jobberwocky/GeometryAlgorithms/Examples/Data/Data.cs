namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Data
	{
		public static Shape Get(ShapeType type)
		{
			Shape shape = null;
			return type switch
			{
				ShapeType.Bird => new Bird(), 
				ShapeType.Circle => new Circle(), 
				ShapeType.CircleWithHole => new CircleWithHole(), 
				ShapeType.Cube => new Cube(), 
				ShapeType.Dude => new Dude(), 
				ShapeType.Horse13k => new Horse13k(), 
				ShapeType.Owl15k => new Owl15k(), 
				ShapeType.Random2D => new Random2D(), 
				ShapeType.Random3D => new Random3D(), 
				ShapeType.Sphere => new Sphere(), 
				ShapeType.Square => new Square(), 
				ShapeType.SquareWithHole => new SquareWithHole(), 
				ShapeType.Tank => new Tank(), 
				_ => new Dude(), 
			};
		}
	}
}
