using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(100);
int x = 0;
int floorY =550;
int floorSpeedY =-1;
Vector2 movement = new Vector2(1,0);
Vector2 position = new Vector2(2,1);

Color hotpink= new Color(255, 105, 180, 225);

Texture2D characterImage = Raylib.LoadTexture("gubbe.png");
Rectangle characterRect = new Rectangle(10, 10, 32, 32);
characterRect.width = characterImage.width;
characterRect.height = characterImage.height;

float speed = 5;

while (!Raylib.WindowShouldClose())
{
    movement = Vector2.Zero;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {   
        movement.X = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {   
        movement.X = 1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {   
        movement.Y = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {   
        movement.Y = 1;
    }

    if (movement.Length() > 0)
    {
       movement = Vector2.Normalize(movement); 
    }
    

    movement *= speed;

    characterRect.x += movement.X;
    characterRect.y += movement.Y;

    
    floorY += floorSpeedY;
    if (floorY <0)
    {
        floorSpeedY =1;
    }
    else if (floorY>550)
    {
        floorSpeedY = -1;
    }
    position += movement;
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLUE);

    //Raylib.DrawCircle(x,300,30, Color.DARKBLUE);
    //Raylib.DrawCircleV(position, 20, hotpink);

    Raylib.DrawRectangle(0, floorY, 800, 30, Color.BLACK);
    Raylib.DrawRectangleRec(characterRect, Color.BLUE);
    Raylib.DrawTexture(characterImage, (int) characterRect.x, (int) characterRect.y, Color.WHITE);

    Raylib.EndDrawing();
}


