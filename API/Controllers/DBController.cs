using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DBController : ControllerBase
    {
        //Выборка веса (для графика)
        public IResult SelectWeights(int userID)
        {
            Weight[]? result = null;
            using (KcalPlannerDbContext db = new KcalPlannerDbContext())
            {
                result = db.Weights.Where(x => x.IdUser == userID).ToArray();
            }
            return Results.Json(result);
        }

        //Выборка продуктов (для таблицы)
        public IResult SelectUserProducts(int userID)
        {
            UserProduct[]? result = null;
            using (KcalPlannerDbContext db = new KcalPlannerDbContext())
            {
                result = db.UserProducts.Where(x => x.IdUser == userID).ToArray();
            }
            return Results.Json(result);
        }

        //public IResult AddUser(User newUser)
        //{
        //    using (KcalPlannerDbContext db = new KcalPlannerDbContext())
        //    {
        //        User? user = db.Users.FirstOrDefault(p => p.Email == newUser.Email);
        //        if (user == null)
        //        {

        //        }
        //        else
        //        {
        //            return Results.NotFound(new { message = "Пользователь уже существует" });

        //        }
        //    }
        //}

        //Добавление цели
        public IResult AddAim(Aim newAim)
        {
            using (KcalPlannerDbContext db = new KcalPlannerDbContext())
            {
                Aim? aim = db.Aims.FirstOrDefault(p => p.Name == newAim.Name);
                if (aim == null)
                {
                    db.Aims.Add(newAim);
                    db.SaveChanges();
                    return Results.Json(newAim);
                }
                else
                {
                    return Results.NotFound(new { message = "Цель уже существует" });
                }
            }
        }

        //Добавление активности
        public IResult AddActivity(Activity newAct)
        {
            using (KcalPlannerDbContext db = new KcalPlannerDbContext())
            {
                Activity? act = db.Activities.FirstOrDefault(p => p.Name == newAct.Name);
                if (act == null)
                {
                    db.Activities.Add(newAct);
                    db.SaveChanges();
                    return Results.Json(newAct);
                }
                else
                {
                    return Results.NotFound(new { message = "Цель уже существует" });
                }
            }
        }
    }
}
