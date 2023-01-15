
class Program
{
    static int passengerRequest()
    {
        int call = Random.Shared.Next(0, 11);

        Console.WriteLine($"privolali ma na {call}.poschodie...idem tam");
        Thread.Sleep(1000);

        return call;
    }


    static int passengerRide()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("vyberte poschodie 0 - 10: ");
                
                int floorRequest = Convert.ToInt32(Console.ReadLine());
                
                if (Enumerable.Range(0, 11).Contains(floorRequest))
                {
                    Console.WriteLine($"ideme na {floorRequest}. poschodie");
                    Thread.Sleep(500);

                    return floorRequest;
                }
            }

            catch
            {
                continue;
            }
        }
    }


    static int goUp(int request, int floor)
    {
        while (request != floor)
        {
            Console.WriteLine(floor);
            Thread.Sleep(500);

            Console.WriteLine("idem hore");
            Thread.Sleep(500);

            floor++;
        }

        Console.WriteLine(floor);

        return floor;
    }


    static int goDown(int request, int floor)
    {
        while (request != floor)
        {
            Console.WriteLine(floor);
            Thread.Sleep(500);

            Console.WriteLine("idem dole");
            Thread.Sleep(500);

            floor--;
        }

        Console.WriteLine(floor);

        return floor;
    }


    static string exitMessage(int newFloor)
    {
        return $"sme na {newFloor}.poschodi";
    }


    static int decision(int request, int floor)
    {
        int newFloor = 0;
        string message = "";

        if (request == floor)
        {
            newFloor = floor;
            message = exitMessage(newFloor);
        }

        else if (request > floor)
        {
            newFloor = goUp(request, floor);
            message = exitMessage(newFloor);
        }

        else
        {
            newFloor = goDown(request, floor);
            message = exitMessage(newFloor);
        }

        Console.WriteLine(message);
        Thread.Sleep(1000);

        return newFloor;
    }


    static void Elevator()
    {
        string[] starterLst = { "VÝŤAH SA ZAPÍNA", "-----ON-----", "čakám, kým ma niekto privolá" };

        foreach (string item in starterLst)
        {
            Console.WriteLine(item);
            Thread.Sleep(1000);
        }

        int ride = 1;
        int startFloor = 0;

        while (ride < 5)
        {
            int passRequest = passengerRequest();
            int passPickup = decision(passRequest, startFloor);
            int passSelection = passengerRide();
            int passRide = decision(passSelection, passPickup);

            System.Console.WriteLine("DOVIDENIA");
            Thread.Sleep(700);

            startFloor = passRide;

            ride++;
        }

        System.Console.WriteLine("PORUCHA!!! vytah sa pokazil...pouzite prosim schodisko");
        Thread.Sleep(700);
        System.Console.WriteLine("-----OFF-----");
    }


    static void Main(string[] args)
    {
        Elevator();
    }

}
