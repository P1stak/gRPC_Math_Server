using Grpc.Core;
using Quadratic;
using System;
using System.Threading.Tasks;
namespace gRPS_Math_Server.Services
{
    public class QuadraticSolverService : Quadratic.QuadraticSolver.QuadraticSolverBase
    {
        public override Task<QuadraticResponse> SolveQuadraticEquation(QuadraticRequest request, ServerCallContext context)
        {
            double a = request.A;
            double b = request.B;
            double c = request.C;

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return Task.FromResult(new QuadraticResponse { Root1 = root1, Root2 = root2 });
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return Task.FromResult(new QuadraticResponse { Root1 = root });
            }
            else
            {
                return Task.FromResult(new QuadraticResponse());
            }
        }
    }
}
