using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class NegProduto
    {

        public List<vproduto_categoria> ConsultarProduto(int? intProdutoId)
        {
            try
            {
                List<vproduto_categoria> produtoColecao = new List<vproduto_categoria>();

                using (var bancoDados = new webservicesEntities())
                {
                    var produtoSelecionado = from p in bancoDados.vproduto_categoria
                                             where ((p.Id.Equals(intProdutoId)) ||
                                                   (intProdutoId == null))
                                             select p;

                    if (produtoSelecionado.Count() > 0)
                    {
                        foreach (vproduto_categoria item in produtoSelecionado)
                        {
                            vproduto_categoria novoItem = new vproduto_categoria();
                            novoItem.Id = item.Id;
                            novoItem.ProdutoDesc = item.ProdutoDesc;
                            novoItem.DataCadastro = item.DataCadastro;
                            novoItem.CategoriaId = item.CategoriaId;
                            novoItem.CategoriaDesc = item.CategoriaDesc;

                            produtoColecao.Add(novoItem);
                        }
                    }
                }


                return produtoColecao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
