export interface Lote {
  id: number;
  nome: string;
  preco: number;
  dataInicio?: Date;
  dataFim?: Date;
  quantiade: number;
  eventoId: number;
}
