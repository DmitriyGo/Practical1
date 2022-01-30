using Practical1.Ships;

namespace Practical1;

public class Aplication
{
    private readonly GameProperties gameProp = new GameProperties(10);

        public void Game()
        {
            AddShip(new Warship("Аврора",1, (2, 2), 5, false,100));
            AddShip(new AuxiliatyShip("Эсминец",5, (6, 2), 5, true,200));
            AddShip(new MixedTypeShip("Авианосец",3, (8, 8), 3, false,150,150));
            AddShip(new Warship("Фрегат",1, (0, 0), 5, false,300));
            AddShip(new MixedTypeShip("Десантный корабль",5, (3, 9), 5, false,200,100));

            ShowField();

            Console.WriteLine("sheepOnField[0] == sheepOnField[3] - {0}", gameProp.ShipsOnField[0] == gameProp.ShipsOnField[3]);
            Console.WriteLine("sheepOnField[0] == sheepOnField[2] - {0}", gameProp.ShipsOnField[0] == gameProp.ShipsOnField[2]);

            Console.WriteLine();
            Console.WriteLine(gameProp[(2, 2)].ToString());
            Console.WriteLine(gameProp[(3, 9)].ToString());
            Console.WriteLine();

            ShowFieldInfo();
        }

        private void AddShip(Ship ship)
        {
            try
            {
                if (!ship.IsVertical)
                {
                    int startCoordinate = ship.Position.X - (ship.Length / 2);

                    for (int i = startCoordinate; i < ship.Length + startCoordinate; i++)
                    {
                        if (gameProp.Field[ship.Position.Y, i] != 0)
                        {
                            return;
                        }
                    }

                    for (int i = startCoordinate; i < ship.Length + startCoordinate; i++)
                    {
                        gameProp.Field[ship.Position.Y, i] = gameProp.ShipsOnField.Count + 1;
                    }

                    gameProp.ShipsOnField.Add(ship);
                }
                else
                {
                    int startCoordinate = ship.Position.Y - (ship.Length / 2);

                    for (int i = startCoordinate; i < ship.Length + startCoordinate; i++)
                    {
                        if (gameProp.Field[i, ship.Position.X] != 0)
                        {
                            return;
                        }
                    }

                    for (int i = startCoordinate; i < ship.Length + startCoordinate; i++)
                    {
                        gameProp.Field[i, ship.Position.X] = gameProp.ShipsOnField.Count + 1;
                    }

                    gameProp.ShipsOnField.Add(ship);
                }
            }
            catch
            {
                Console.WriteLine("One of the ships does not meet the accommodation requirements");
                return;
            }
        }

        private void ShowFieldInfo()
        {
            double middlePoint = Math.Sqrt(gameProp.Field.Length) / 2;
            double[,] tempArr = new double[gameProp.ShipsOnField.ToArray().Length, 2];

            for (int i = 0; i < tempArr.Length / 2; i++)
            {
                tempArr[i, 0] = i;
                tempArr[i, 1] = gameProp.LengthBetweenPoints(gameProp.ShipsOnField[i].Position, (middlePoint, middlePoint));
            }

            for (int i = 0; i < tempArr.Length / 2; i++)
            {
                for (int j = 0; j < (tempArr.Length / 2) - 1; j++)
                {
                    if (tempArr[j, 1] > tempArr[j + 1, 1])
                    {
                        (tempArr[j, 0], tempArr[j + 1, 0]) = (tempArr[j + 1, 0], tempArr[j, 0]);
                        (tempArr[j, 1], tempArr[j + 1, 1]) = (tempArr[j + 1, 1], tempArr[j, 1]);
                        break;
                    }
                }
            }

            for (int i = 0; i < tempArr.Length / 2; i++)
            {
                gameProp.ShipsOnFieldSorted.Add(gameProp.ShipsOnField[(int)tempArr[i, 0]]);
                Console.WriteLine(gameProp.ShipsOnFieldSorted[i].ToString());
            }
        }

        private void ShowField()
        {
            for (int i = 0; i < Math.Sqrt(gameProp.Field.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(gameProp.Field.Length); j++)
                {
                    Console.Write("{0} ", gameProp.Field[i, j]);
                }

                Console.Write("\n");
            }

            Console.WriteLine(); 
        }
}