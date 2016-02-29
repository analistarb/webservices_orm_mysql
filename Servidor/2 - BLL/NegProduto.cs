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

        public List<produto> ConsultarProduto(int? intProdutoId)
        {
            try
            {
                List<produto> produtoColecao = new List<produto>();

                using (var bancoDados = new webserviceEntities())
                {
                    var produtoSelecionado = from p in bancoDados.produto
                                             where ((p.ProdutoId.Equals(intProdutoId)) ||
                                                   (intProdutoId == null))
                                             select p;

                    if (produtoSelecionado.Count() > 0)
                    {
                        foreach (produto item in produtoSelecionado)
                        {
                            produto novoItem = new produto();
                            novoItem.ProdutoId = item.ProdutoId;
                            novoItem.Descricao = item.Descricao;
                            novoItem.DataCadastro = item.DataCadastro;
                            novoItem.ProdutoCategoriaId = item.ProdutoCategoriaId;


                            //novoItem.produtocategoria = new produtocategoria
                            //{
                            //    ProdutoCategoriaId = item.produtocategoria.ProdutoCategoriaId,
                            //    Descricao = item.produtocategoria.Descricao
                            //};

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
